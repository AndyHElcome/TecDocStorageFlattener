
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using TecDocStorageFlattener.Configuration;
using TecDocStorageFlattener.Helpers;
using TecDocStorageFlattener.Models.Contexts.Supplier;
using Xc4.DataTransferObjects.TecDoc.API.Storage.Staging;

namespace TecDocStorageFlattener.Tasks;
public interface ITasks
{
    List<ISupplierConfig>? GlobalConfigs { get; set; }
    //Task Execute();
}   

public interface IDataGatherTasks : ITasks
{
    Task Execute();
}

public abstract class DataGatherTasks : IDataGatherTasks
{
    public List<ISupplierConfig>? GlobalConfigs { get; set; } = new();
    public IEnumerable<Supplier> Suppliers;
    public List<IDataLoadTasks> DataLoadTasks = new();

    public virtual async Task Execute()
    {
        Suppliers = await Gather();

        foreach (var dataLoadTask in DataLoadTasks)
        {
            dataLoadTask.GlobalConfigs = GlobalConfigs;
            Suppliers = await dataLoadTask.Execute(Suppliers);
        }
    }

    public abstract Task<IEnumerable<Supplier>> Gather();
}

public interface IReadJson
{
    Stream? Read(string filePath, string fileName);
    Stream ReadArticles();
    Stream ReadLinkages();
}

public class ReadJson : JsonConfig, IReadJson
{
    public Stream? Read(string filePath, string fileName)
    {
        return File.OpenRead(filePath);
    }

    public Stream ReadArticles()
    {
        if (ArticlesFilePath is null)
            throw new InvalidOperationException("ArticlesFilePath is not set");

        return this.Read(ArticlesFilePath, ArticlesFileName) ?? throw new InvalidOperationException("Could not open stream from source file");
    }

    public Stream ReadLinkages()
    {
        if (LinkagesFilePath is null)
            throw new InvalidOperationException("LinkagesFilePath is not set");

        return this.Read(LinkagesFilePath, LinkagesFileName) ?? throw new InvalidOperationException("Could not open stream from source file");
    }
}

public class ReadJsonZip : JsonConfig, IReadJson
{
    public Stream? Read(string filePath, string fileName)
    { 
        return new UnzipDocuments { SourceFileName = filePath }.GetZipArchiveStream(fileName)?.Open();
    }

    public Stream ReadArticles()
    {
        if (ArticlesFilePath is null)
            throw new InvalidOperationException("ArticlesFilePath is not set");

        return this.Read(ArticlesFilePath, ArticlesFileName) ?? throw new InvalidOperationException("Could not open stream from source file");
    }

    public Stream ReadLinkages()
    {
        if (LinkagesFilePath is null)
            throw new InvalidOperationException("LinkagesFilePath is not set");

        return this.Read(LinkagesFilePath, LinkagesFileName) ?? throw new InvalidOperationException("Could not open stream from source file");
    }
}


public class GatherSuppliersJson : DataGatherTasks
{
    public required string Filepath { get; init; } //e.g @"AppData/Data/OutputXc3"
    public string FileNamePattern { get; set; } = "*"; //e.g $"Client{clientReference}.*.zip"
    public string? BrandNo { get; set; } //e.g "6402"

    //public override Task Execute()
    //{
    //    return base.Execute();
    //}

    public override async Task<IEnumerable<Supplier>> Gather()
    {
        var sourceFileName = Directory.GetFiles(Filepath, FileNamePattern ?? "*").OrderDescending(StringComparer.OrdinalIgnoreCase);
        var suppliers = new List<Supplier>();

        if (sourceFileName.IsNullOrEmpty())
            throw new InvalidOperationException("Could not find source file(s)");

        foreach (var file in sourceFileName)
        {
            //TODO Logging
            Console.WriteLine($"Loading suppliers from: {file}");

            string[] extensions = [ ".zip", ".7z" ];
            if (extensions.Contains(Path.GetExtension(file)))
            {
                Console.WriteLine($"Unzip from: {file}");
                suppliers.Add(new Supplier() { BrandNo = BrandNo, SupplierConfigs = [ new ReadJsonZip() { ArticlesFilePath = file, LinkagesFilePath = file } ] });
            }
            else if (Path.GetExtension(file) == ".json")
            {
                Console.WriteLine($"Read from: {file}");
                suppliers.Add(new Supplier() { BrandNo = BrandNo, SupplierConfigs = [ new ReadJson() { ArticlesFilePath = file, LinkagesFilePath = file } ] });
            }
            else
                throw new InvalidOperationException("Source file must be a .json file or zipped .json file");
        }

        return suppliers;
    }


}

public interface IDataLoadTasks : ITasks
{
    List<ISupplierConfig>? GlobalConfigs { get; set; }
    //public List<Supplier> Suppliers { get; set; }
    Task<IEnumerable<Supplier>> Execute(IEnumerable<Supplier> Suppliers);
}

public abstract class DataLoadTasks : IDataLoadTasks, IDisposable
{
    public List<ISupplierConfig>? GlobalConfigs { get; set; } = new();
    public List<IDataImportTasks> DataImportTasks { get; set; }

    //public List<Supplier> Suppliers { get; set; } = new();

    public virtual async Task<IEnumerable<Supplier>> Execute(IEnumerable<Supplier> Suppliers)
    {
        if (Suppliers == null || !Suppliers.Any())
            throw new InvalidOperationException($"No suppliers to load for {this.GetType().Name}");

        return await Load(Suppliers);
    }

    public abstract Task<IEnumerable<Supplier>> Load(IEnumerable<Supplier> Suppliers);

    public abstract void Dispose();
}



public class LoadFromJson : DataLoadTasks
{

    public override async Task<IEnumerable<Supplier>> Load(IEnumerable<Supplier> Suppliers)
    {
        foreach (var dataImportTask in DataImportTasks)
        {
            dataImportTask.GlobalConfigs = GlobalConfigs;
        }

        foreach (var supplier in Suppliers)
        {
            var newSupplier = supplier; //Avoid modified closure

            IReadJson readJson = supplier.SupplierConfigs?.OfType<IReadJson>().FirstOrDefault() ?? throw new InvalidOperationException("No ReadJson config found");

            using (Stream? stream = readJson.ReadArticles())
            {
                if (stream == null)
                    throw new InvalidOperationException("Could not open stream from source file");

                try
                {
                    //var test = JsonSerializer.Deserialize<List<Xc4.DataTransferObjects.TecDoc.API.Storage.Staging.PutArticlesItem>>(stream, JsonSerializerHelpers.JsonSerializerOptions);

                    //TODO ERROR HERE -- DID WORK ONCE
                    var sourceDocuments = JsonSerializer.DeserializeAsyncEnumerable<Xc4.DataTransferObjects.TecDoc.API.Storage.Staging.PutArticlesItem>(stream, JsonSerializerHelpers.JsonSerializerOptions);
                    //.Where(c => !string.IsNullOrEmpty(c?.Article?.ArtNo))
                    //.Chunk(50);
                    await foreach (var chunk in sourceDocuments)
                    {
                        foreach (var DataImportTask in DataImportTasks)
                        {
                            newSupplier = await DataImportTask.ImportArticles([ chunk! ], newSupplier);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
                finally
                {
                    stream.Dispose();
                }

            }
            using (Stream? stream = readJson.ReadLinkages())
            {
                var sourceDocuments = JsonSerializer.DeserializeAsyncEnumerable<Xc4.DataTransferObjects.TecDoc.API.Storage.Staging.PutLinkagesItem>(stream, JsonSerializerHelpers.JsonSerializerOptions)
                    //.Where(c => !string.IsNullOrEmpty(c?.Article?.ArtNo))
                    .Chunk(50);
                await foreach (var chunk in sourceDocuments)
                    foreach (var DataImportTask in DataImportTasks)
                        newSupplier = await DataImportTask.ImportLinkages(chunk!, newSupplier);
            }

        }

        return Suppliers;
    }

    public override void Dispose()
    {

    }
}


public interface IDataImportTasks
{
    List<ISupplierConfig>? GlobalConfigs { get; set; }

    Task<Supplier> ImportArticles(PutArticlesItem[] articles, Supplier supplier);
    Task<Supplier> ImportLinkages(PutLinkagesItem[] articles, Supplier supplier);
}

public class SQLLoadTasks : IDataImportTasks
{
    public List<ISupplierConfig>? GlobalConfigs { get; set; } = new();
    public SupplierDBConfig? SupplierDBConfig;
    public ReferenceDBConfig? ReferenceDBConfig;

    public async Task<Supplier> ImportArticles(PutArticlesItem[] articles, Supplier supplier)
    {
        short BrandNo = Convert.ToInt16(articles.First().Article?.BrandNo ?? throw new InvalidOperationException("No BrandNo found"));
        supplier.BrandNo ??= BrandNo.ToString();

        SupplierDBConfig supplierDBConfig = supplier.SupplierConfigs?.OfType<SupplierDBConfig>().FirstOrDefault() ?? SupplierDBConfig ?? GlobalConfigs?.OfType<SupplierDBConfig>().FirstOrDefault() ?? throw new InvalidOperationException("No SupplierDBConfig found");
        ReferenceDBConfig referenceDBConfig = supplier.SupplierConfigs?.OfType<ReferenceDBConfig>().FirstOrDefault() ?? ReferenceDBConfig ?? GlobalConfigs?.OfType<ReferenceDBConfig>().FirstOrDefault() ?? throw new InvalidOperationException("No ReferenceDBConfig found");

        supplierDBConfig.ConnectionStringConfig.BrandNo ??= supplier.BrandNo;

        using var supplierDataContext = supplierDBConfig.CreateDBFactory(null).GetDataContext(supplier.BrandNo);

        foreach (var article in articles)
        {

            await supplierDataContext.T200.AddAsync(new()
            {
                PartNo = article.Article.ArtNo!,
                BrandNo = (short)article.Article.BrandNo,
                DescriptionTermNo = 0,
                SelfServicePacking = article.Article.SelfService,
                MandatoryMaterialCertification = article.Article.MatCert,
                RemanufacturedPart = article.Article.Remanufactured,
                Accessory = article.Article.IsAccessory,
                BatchSize1 = article.Article.BatchSize1,
                BatchSize2 = article.Article.BatchSize2,
            });
        }
        //TODO Implement TecDoc Import

        return supplier;
    }

    public async Task<Supplier> ImportLinkages(PutLinkagesItem[] articles, Supplier supplier)
    {

        return supplier;
    }
}
