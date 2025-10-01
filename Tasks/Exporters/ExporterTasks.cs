using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using TecDocStorageFlattener.Models.Contexts.TecdocReference22;
using TecDocStorageFlattener.Configuration;
using TecDocStorageFlattener.Helpers;
using TecDocStorageFlattener.Models.Contexts.Supplier;
using Xc4.DataTransferObjects.TecDoc.API.Storage.Staging;
using Xc4.DataTransferObjects.TecDoc.Models.IDP.Requests.Article;
using TafLoader.Models.Tecdoc;



namespace TecDocStorageFlattener.Tasks.Exporters;

public abstract class ExporterTasks : ITasks, IDisposable
{
    public PutArticlesItem[]? Articles { get; set; }
    public PutLinkagesItem[]? Linkages { get; set; }

    public virtual async Task Execute()
    {
        if (Articles != null)
            await Export(Articles);
        if (Linkages != null)
            await Export(Linkages);
    }



    public abstract Task Export(PutArticlesItem[] articles);
    public abstract Task Export(PutLinkagesItem[] articles);

    public abstract void Dispose();
}

public class ExportSQL() : ExporterTasks
{
    public  ILogger Logger { get; init; }

    public  string ConnectionString { get; init; }
    public  string ReferenceDataConnectionString { get; init; }

    // private SupplierDataContext? supplierDataContext;
    //private TecdocReference22DbContext? referenceDataContext;

    private TecdocDbContext? supplierDataContext;
    private TecdocDbContext? referenceDataContext;

    private SupplierDBConfiguration SupplierDBConfig => new()
    {
        ConnectionString = this.ConnectionString
    };
    private ReferenceDBConfiguration ReferenceDBConfig => new()
    {
        ConnectionString = this.ReferenceDataConnectionString
    };

    private TAFSupplierDBConfiguration SupplierDBConfig2 => new()
    {
        ConnectionString = this.ConnectionString
    };
    private TAFReferenceDBConfiguration ReferenceDBConfig2 => new()
    {
        ConnectionString = this.ReferenceDataConnectionString
    };

    private void StoreDataContext(string database)
    {
        supplierDataContext ??= SupplierDBConfig2.CreateDBFactory(Logger).GetDataContext(database);
        referenceDataContext ??= ReferenceDBConfig2.CreateDBFactory(Logger).GetDataContext("ref");
    }

    public override async Task Execute()
    {
        SupplierDBConfig2.CreateDBFactory(Logger).DropDB();
    }

    public override async Task Export(PutArticlesItem[] articles)
    {
        short BrandNo = Convert.ToInt16(articles.First().Article?.BrandNo ?? throw new InvalidOperationException("No BrandNo found"));
        short sort = 0;

        StoreDataContext(BrandNo.ToString());



        //Dictionary<string, (List<DataSupplierTranslation> DataSupplierTranslations, HashSet<DataSupplierTranslation> HashSet)>? AddArtNameCache
        //    = supplierDataContext!.Dat030.Join(referenceDataContext!.In020s,
        //                                       dat => dat.LangNo,
        //                                       reference => reference.SprachNr.ToString(),
        //                                       (dat, reference) => new { dat.TermNo, dat.Term, reference.Isocode })
        //                                 .GroupBy(g => g.TermNo!)
        //                                 .Select(s => new { TermNo = s.Key, DataSupplierTranslations = s.Select(c => new DataSupplierTranslation { Term = c.Term, Language = c.Isocode }).ToList() })
        //                                 .ToDictionary(k => k.TermNo,
        //                                               v => (v.DataSupplierTranslations, new HashSet<DataSupplierTranslation>(v.DataSupplierTranslations)));

        // No join but uses the helper need to test speed
        Dictionary<int, (List<DataSupplierTranslation> DataSupplierTranslations, HashSet<DataSupplierTranslation> HashSet)>? AddArtNameCache
            = supplierDataContext!.T030.GroupBy(g => g.TermNo!)
                                         .Select(s => new { TermNo = s.Key, DataSupplierTranslations = s.Select(c => new DataSupplierTranslation { Term = c.Term, Language = c.LangNo == 255 ? null : referenceDataContext!.GetLanguageFromSprachNr(c.LangNo).IsoCode }).ToList() })
                                         .ToDictionary(k => k.TermNo,
                                                       v => (v.DataSupplierTranslations, new HashSet<DataSupplierTranslation>(v.DataSupplierTranslations)));





        foreach (var article in articles)
        {
            if (article.Article == null)
                continue;
            if (article.Article.BrandNo != BrandNo)
                throw new Exception("BrandNo has changed?");

            int addArtNameReference = 1;

            // Load 030
            if ( !article.Article.AddArtName.IsNullOrEmpty())
            {
                var addArtNameHashSet = new HashSet<DataSupplierTranslation>(article.Article.AddArtName!);

                var matchingEntry = AddArtNameCache
                    .FirstOrDefault(kvp => EqualityHelpers.AreHashSetEqual(kvp.Value.HashSet, addArtNameHashSet)).Key;

                if (matchingEntry != 0)
                {
                    addArtNameReference = matchingEntry;
                }
                else
                { 
                    addArtNameReference = supplierDataContext.T030.Max(m => m.TermNo) + 1; //TODO still need to create a proper beznr

                    AddArtNameCache.Add(addArtNameReference, (article.Article.AddArtName!.ToList(), addArtNameHashSet));

                    foreach (var term in article.Article.AddArtName!)
                    {
                        await supplierDataContext.T030.AddAsync(new ()
                        {
                            BrandNo = (short)article.Article.BrandNo,
                            TermNo = addArtNameReference ,
                            LangNo = term.Language.IsNullOrEmpty() ? (short)255 : referenceDataContext.GetLanguageFromISOCode(term.Language).LangNo,
                            Term = term.Term!
                        });
                    }
                }
            }


            // Load 200
            await supplierDataContext.T200.AddAsync(new ()
            {
                PartNo = article.Article.ArtNo!,
                BrandNo = (short)article.Article.BrandNo,
                DescriptionTermNo = addArtNameReference,
                SelfServicePacking = article.Article.SelfService,
                MandatoryMaterialCertification = article.Article.MatCert,
                RemanufacturedPart = article.Article.Remanufactured,
                Accessory = article.Article.IsAccessory,
                BatchSize1 = article.Article.BatchSize1,
                BatchSize2 = article.Article.BatchSize2,
            });

            //TODO load 201

            //TODO load 202

            // Load 203
            sort = 0;
            foreach (var crossreference in article.Article.ReferenceNumbers)
            {

                // TODO Add for countries
                await supplierDataContext.T203.AddAsync(new ()
                {
                    PartNo = article.Article.ArtNo!,
                    BrandNo = (short)article.Article.BrandNo,
                    ManufacturerNo = (int)crossreference.ManufacturerNumber,
                    CountryCode = string.Empty,
                    ReferencePartNo = crossreference.ReferenceNumber!,
                    SortNo = (++sort),
                    //Exclude = null,
                    ReferenceTypeKey = crossreference.ReferenceInfo
                });
            }

            // Load 204
            sort = 0;
            foreach (var supercession in article.Article.SupersededArticles)
            {

                // TODO Add for countries
                await supplierDataContext.T204.AddAsync(new ()
                {
                    PartNo = article.Article.ArtNo!,
                    BrandNo = (short)article.Article.BrandNo,
                    CountryCode = string.Empty,
                    SupersededPartNo = supercession.SupersNo!,
                    //Exclude = null,
                    SortNo = (++sort),
                });
            }

            //TODO Load 205

            //TODO Load 206

            // Load 207
            sort = 0;
            foreach (var tradeNumber in article.Article.TradeNumbers)
            {

                // TODO Add for countries
                await supplierDataContext.T207.AddAsync(new()
                {
                    PartNo = article.Article.ArtNo!,
                    BrandNo = (short)article.Article.BrandNo,
                    CountryCode = string.Empty,
                    TradeNumber = tradeNumber.TradeNo,
                    FirstPage = tradeNumber.ShowImmediate,
                    //Exclude = null,
                    SortNo = (++sort),
                });
            }

            //TODO Load 208

            // Load 209
            if (!article.Article.Gtins.IsNullOrEmpty())
            {
                foreach (var gtin in article.Article.Gtins)
                {

                    // TODO Add for countries
                    await supplierDataContext.T209.AddAsync(new()
                    {
                        PartNo = article.Article.ArtNo!,
                        BrandNo = (short)article.Article.BrandNo,
                        CountryCode = string.Empty,
                        GTIN = Convert.ToInt64(gtin.Num),
                        //Exclude = null,
                    });
                }
            }

            // Load 210
            sort = 0;
            foreach (var criteria in article.Article.Criteria)
            {

                // TODO Add for countries
                await supplierDataContext.T210.AddAsync(new()
                {
                    PartNo = article.Article.ArtNo!,
                    BrandNo = (short)article.Article.BrandNo,
                    CountryCode = string.Empty,
                    SortNo = (++sort),
                    CritNo = (short)criteria.CritNo,
                    CritVal = criteria.CritVal!,
                    FirstPage = criteria.ShowImmediate ?? false,
                    //Exclude = null,
                });
            }

            // Load 211
            foreach (var genart in article.Article.GenArtNos)
            {
                await supplierDataContext.T211.AddAsync(new()
                {
                    PartNo = article.Article.ArtNo!,
                    BrandNo = (short)article.Article.BrandNo,
                    GenArtNo = genart
                });
            }

            // Load 212
            foreach (var status in article.Article.Statuses)
            {
                if (status.Countries.IsNullOrEmpty())
                {
                    await supplierDataContext.T212.AddAsync(new ()
                    {
                        PartNo = article.Article.ArtNo!,
                        BrandNo = (short)article.Article.BrandNo,
                        CountryCode = null,
                        QuantityPerPackage = status.QuantityUnit,
                        QuantityPartPerUnit = status.QuantityPerUnit,
                        ArticleStatusKey = (short)status.Status!,
                        ArticleStatusFromDateYYYYMMDD = status.StatusDate,

                    });
                }
                else
                {
                    foreach (var country in status.Countries!)
                    {
                        await supplierDataContext.T212.AddAsync(new ()
                        {
                            PartNo = article.Article.ArtNo!,
                            BrandNo = (short)article.Article.BrandNo,
                            CountryCode = referenceDataContext.GetCountryFromISOCode(country)!.CountryCode,
                            QuantityPerPackage = status.QuantityUnit,
                            QuantityPartPerUnit = status.QuantityPerUnit,
                            ArticleStatusKey = (short)status.Status!,
                            ArticleStatusFromDateYYYYMMDD = status.StatusDate,
                        });
                    }
                }
            }

            //TODO Load 213 MAYBE

            //TODO Load 215

            //TODO Load 217

            //TODO Load 222

            //TODO Load 228

            //TODO Load 231

            //TODO Load 232

            //TODO Load 233

        }
        await supplierDataContext.SaveChangesAsync();
    }


    public override async Task Export(PutLinkagesItem[] linkages)
    {
        throw new NotImplementedException();
    }

    public override void Dispose()
    {
        try
        {
            supplierDataContext.Dispose();
            referenceDataContext.Dispose();
        }
        catch (Exception ex)
        {
            // Log error and continue
            Logger.Error(ex, $"DatabaseFactory: Failed to dispose DbContext");
        }
    }
}

