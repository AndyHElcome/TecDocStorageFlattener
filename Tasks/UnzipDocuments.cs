using System.IO.Compression;
using TafLoader.Models.Tecdoc;
using TecDocStorageFlattener.Configuration;
using TecDocStorageFlattener.Tasks.Exporters;





namespace TecDocStorageFlattener.Tasks;
public class UnzipDocuments
{
    public required string SourceFileName { get; init; }
    public string? DestinationFileName { get; set; }

    public async Task Execute()
    {
        if (string.IsNullOrEmpty(DestinationFileName))
            DestinationFileName = Path.ChangeExtension(SourceFileName, "\\"); //TODO Test works
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

//public class DropDatabase() : ITasks
//{
//    public string ConnectionString { get; init; }

//    public async Task Execute()
//    {
        
//    }
//}