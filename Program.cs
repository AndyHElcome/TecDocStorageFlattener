// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;
using System.Text.Json;
using System.Threading.Tasks;

Console.WriteLine("Hello, World!");














/*
static async Task OutputXc3Data(IServiceProvider serviceProvider, long clientReference)
{
    var jsonSerializerOptions = serviceProvider.GetRequiredService<JsonSerializerOptions>();
    var tecDocDebugFileWriter = serviceProvider.GetRequiredService<Tasks.Output.TecDocDebugFileWriter>();
    var sourceFileName = Directory.GetFiles(@"AppData/Data/OutputXc3", $"Client{clientReference}.*.zip").OrderDescending(StringComparer.OrdinalIgnoreCase).FirstOrDefault();
    using var zipFileSource = new ZipArchive(File.OpenRead(sourceFileName), ZipArchiveMode.Read);
    {
        using var stream = zipFileSource.GetEntry("Articles.json").Open();
        using var writer = await tecDocDebugFileWriter.CreateDiffArticleWriter(new(clientReference, "OutputXc3"));
        var sourceDocuments = JsonSerializer.DeserializeAsyncEnumerable<Xc4.DataTransferObjects.TecDoc.API.Storage.Staging.PutArticlesItem>(stream, jsonSerializerOptions)
            .Where(c => !string.IsNullOrEmpty(c?.Article?.ArtNo))
            .Chunk(50);
        await foreach (var chunk in sourceDocuments)
            await writer.Write(chunk);
    }
    if (true)
    {
        using var stream = zipFileSource.GetEntry("Linkages.json").Open();
        using var writer = await tecDocDebugFileWriter.CreateDiffLinkageWriter(new(clientReference, "OutputXc3"));
        var sourceDocuments = JsonSerializer.DeserializeAsyncEnumerable<Xc4.DataTransferObjects.TecDoc.API.Storage.Staging.PutLinkagesItem>(stream, jsonSerializerOptions)
            .Where(c => !string.IsNullOrEmpty(c?.Linkage?.ArtNo) && Tasks.Output.TecDocDebugModifyForDiff.AllowArtNo(c.Linkage.ArtNo)) // For testing, only generate subset of linkages
            .Chunk(50);
        await foreach (var chunk in sourceDocuments)
            await writer.Write(chunk);
    }
}
*/
