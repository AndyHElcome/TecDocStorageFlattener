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



namespace TecDocStorageFlattener.Tasks.Exporters;

public abstract class ExporterTasks : ITasks, IDisposable
{
    public PutArticlesItem[]? Articles { get; set; }
    public PutLinkagesItem[]? Linkages { get; set; }

    public async Task Execute()
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


    private SupplierDataContext? supplierDataContext;
    private TecdocReference22DbContext? referenceDataContext;

    private SupplierDBConfiguration SupplierDBConfig => new()
    {
        ConnectionString = this.ConnectionString
    };
    private ReferenceDBConfiguration ReferenceDBConfig => new()
    {
        ConnectionString = this.ReferenceDataConnectionString
    };

    private void StoreDataContext(string database)
    {
        supplierDataContext ??= SupplierDBConfig.CreateDBFactory(Logger).GetDataContext(database);
        referenceDataContext ??= ReferenceDBConfig.CreateDBFactory(Logger).GetDataContext("ref");
    }



    public override async Task Export(PutArticlesItem[] articles)
    {
        string BrandNo = articles.First().Article?.BrandNo.ToString() ?? throw new InvalidOperationException("No BrandNo found");

        StoreDataContext(BrandNo);



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
        Dictionary<string, (List<DataSupplierTranslation> DataSupplierTranslations, HashSet<DataSupplierTranslation> HashSet)>? AddArtNameCache
            = supplierDataContext!.Dat030.GroupBy(g => g.TermNo!)
                                         .Select(s => new { TermNo = s.Key, DataSupplierTranslations = s.Select(c => new DataSupplierTranslation { Term = c.Term, Language = c.LangNo == "255" ? null : referenceDataContext.GetLanguageFromSprachNr(c.LangNo).Isocode }).ToList() })
                                         .ToDictionary(k => k.TermNo,
                                                       v => (v.DataSupplierTranslations, new HashSet<DataSupplierTranslation>(v.DataSupplierTranslations)));





        foreach (var article in articles)
        {
            if (article.Article == null)
                continue;
            if (article.Article.BrandNo.ToString() != BrandNo)
                throw new Exception("BrandNo has changed?");

            string? addArtNameReference = null;

            // Load 030
            if ( !article.Article.AddArtName.IsNullOrEmpty())
            {
                var addArtNameHashSet = new HashSet<DataSupplierTranslation>(article.Article.AddArtName!);

                var matchingEntry = AddArtNameCache
                    .FirstOrDefault(kvp => EqualityHelpers.AreHashSetEqual(kvp.Value.HashSet, addArtNameHashSet)).Key;

                if (matchingEntry is not null)
                {
                    addArtNameReference = matchingEntry;
                }
                else
                { 
                    addArtNameReference = (supplierDataContext.Dat030.Max(m => Convert.ToInt32(m.TermNo)) + 1).ToString(); //TODO still need to create a proper beznr

                    AddArtNameCache.Add(addArtNameReference.ToString(), (article.Article.AddArtName!.ToList(), addArtNameHashSet));

                    foreach (var term in article.Article.AddArtName!)
                    {
                        await supplierDataContext.Dat030.AddAsync(new Dat030()
                        {
                            BrandNo = article.Article.BrandNo.ToString(),
                            TableNo = "030",
                            TermNo = addArtNameReference.ToString(),
                            LangNo = term.Language.IsNullOrEmpty() ? "255" : referenceDataContext.GetLanguageFromISOCode(term.Language).SprachNr.ToString(),
                            Term = term.Term,
                            DeleteFlag = "0"
                        });
                    }
                }
            }


            // Load 200
            await supplierDataContext.Dat200.AddAsync(new Dat200()
            {
                ArtNo = article.Article.ArtNo,
                BrandNo = article.Article.BrandNo.ToString(),
                TableNo = "200",
                TermNo = addArtNameReference,
                Selferv = article.Article.SelfService ?? false ? "1" : "0",
                MatCert = article.Article.MatCert ?? false ? "1" : "0",
                Remanufact = article.Article.SelfService ?? false ? "1" : "0",
                Accesory = article.Article.IsAccessory ?? false ? "1" : "0",
                BatchSize1 = article.Article.BatchSize1?.ToString(),
                BatchSize2 = article.Article.BatchSize2?.ToString(),
                DeleteFlag = "0"
            });
            //await supplierDataContext.SaveChangesAsync();
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


public class MyObjectComparer : IEqualityComparer<DataSupplierTranslation>
{
    public bool Equals(DataSupplierTranslation x, DataSupplierTranslation y)
    {
        if (x == null || y == null)
            return false;
        return x.Term == y.Term && x.Language == y.Language;
    }

    public int GetHashCode(DataSupplierTranslation obj)
    {
        if (obj == null)
            return 0;
        return HashCode.Combine(obj.Term, obj.Language);
    }
}
