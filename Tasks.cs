using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO.Compression;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;





public class Tasks
{
    public static IServiceProvider ServiceProvider;

    public abstract class SerialiseTasks
    {

        public abstract Task Execute(); 
    }


    public class UnzipDocuments : SerialiseTasks
    {
        public required string SourceFileName { get; init; }
        public string? DestinationFileName { get; set; }

        public override async Task Execute()
        {
            if (string.IsNullOrEmpty(DestinationFileName))
                DestinationFileName = Path.ChangeExtension(SourceFileName, "\\");
            //DestinationFileName = Path.Combine(Path.GetDirectoryName(SourceFileName), Path.GetFileNameWithoutExtension(SourceFileName));

            using (ZipArchive archive = ZipFile.OpenRead(SourceFileName))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(Path.Combine(DestinationFileName, entry.FullName));
                }
            }
        }

        public ZipArchiveEntry? GetZipArchiveStream(string fileName)
        {
            var zipFileSource = new ZipArchive(File.OpenRead(SourceFileName), ZipArchiveMode.Read);
            return zipFileSource.GetEntry(fileName);
        }
    }


    public class SerialiseArticles : SerialiseTasks
    {
        public required string Filepath { get; init; } //e.g @"AppData/Data/OutputXc3"
        public string FileNamePattern { get; set; } = "*"; //e.g $"Client{clientReference}.*.zip"
        public string FileName { get; set; } = $"Articles.json"; //e.g $"Articles.json"


        public override async Task Execute()
        {
            //var jsonSerializerOptions = ServiceProvider.GetRequiredService<JsonSerializerOptions>();
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };

            Stream? stream;

            var sourceFileName = Directory.GetFiles(Filepath, FileNamePattern ?? "*").OrderDescending(StringComparer.OrdinalIgnoreCase).FirstOrDefault(); //TODO Change to foreach

            if (string.IsNullOrEmpty(sourceFileName))
                throw new InvalidOperationException("Could not find source file");

            string[] extensions = [ ".zip", ".7z" ];
            if (extensions.Contains(Path.GetExtension(sourceFileName)))
            {
                //var unzippedDocuments = new UnzipDocuments { SourceFileName = sourceFileName }.Execute();
                //sourceFileName = unzippedDocuments.DestinationPath;

                stream = new UnzipDocuments { SourceFileName = sourceFileName }.GetZipArchiveStream(FileName)?.Open();
            }
            else if  (Path.GetExtension(sourceFileName) == ".json")
                stream = File.OpenRead(sourceFileName);
            else
                throw new InvalidOperationException("Source file must be a .json file or zipped .json file");

            if (stream == null)
                throw new InvalidOperationException("Could not open stream from source file");

            // Mat's magic
            //var sourceDocuments = JsonSerializer.DeserializeAsyncEnumerable<Xc4.DataTransferObjects.TecDoc.API.Storage.Staging.PutArticlesItem>(stream, jsonSerializerOptions)
            //    .Where(c => !string.IsNullOrEmpty(c?.Article?.ArtNo))
            //    .Chunk(50);
            //await foreach (var chunk in sourceDocuments)
            //    Console.WriteLine("{@chunk}", chunk);



            var sourceDocuments = JsonSerializer.DeserializeAsyncEnumerable<Xc4.DataTransferObjects.TecDoc.API.Storage.Staging.PutArticlesItem>(stream, jsonSerializerOptions); // TODO Broken - fix
            await foreach (var item in sourceDocuments)
                Console.WriteLine("{@item}", item);


            stream.Dispose();

        }
    }


/*
    public async Task OutputXc3Data(IServiceProvider serviceProvider, long clientReference)
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

}
