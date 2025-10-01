using System.Text.Json;
using TecDocStorageFlattener.Helpers;

namespace TecDocStorageFlattener.Tasks.Deserialize;

public class DeserializeLinkages : DeserializeTasks
{
    public required string Filepath { get; init; } //e.g @"AppData/Data/OutputXc3"
    public string FileNamePattern { get; set; } = "*"; //e.g $"Client{clientReference}.*.zip"
    public string FileName { get; set; } = $"Linkages.json"; //e.g $"Articles.json"


    public override async Task Execute()
    {
        Stream? stream;

        var sourceFileName = Directory.GetFiles(Filepath, FileNamePattern ?? "*").OrderDescending(StringComparer.OrdinalIgnoreCase).FirstOrDefault(); //TODO Change to foreach

        if (string.IsNullOrEmpty(sourceFileName))
            throw new InvalidOperationException("Could not find source file");

        string[] extensions = [ ".zip", ".7z" ];
        if (extensions.Contains(Path.GetExtension(sourceFileName)))
            stream = new UnzipDocuments { SourceFileName = sourceFileName }.GetZipArchiveStream(FileName)?.Open();
        else if (Path.GetExtension(sourceFileName) == ".json")
            stream = File.OpenRead(sourceFileName);
        else
            throw new InvalidOperationException("Source file must be a .json file or zipped .json file");

        if (stream == null)
            throw new InvalidOperationException("Could not open stream from source file");

        var sourceDocuments = JsonSerializer.DeserializeAsyncEnumerable<Xc4.DataTransferObjects.TecDoc.API.Storage.Staging.PutLinkagesItem>(stream, JsonSerializerHelpers.JsonSerializerOptions)
            .Where(c => !string.IsNullOrEmpty(c?.Linkage?.ArtNo))
            .Chunk(50);
        await foreach (var chunk in sourceDocuments)
            await Console.Out.WriteLineAsync($"Chunk with {chunk.Length} items. {@chunk[ 0 ].Linkage.ArtNo}");


        stream.Dispose();
    }
}
