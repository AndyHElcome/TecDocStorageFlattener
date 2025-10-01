


using System.Text.Json;
using TecDocStorageFlattener.Helpers;
using TecDocStorageFlattener.Tasks.Exporters;

namespace TecDocStorageFlattener.Tasks.Deserialize;
public abstract class DeserializeTasks : ITasks
{
    public abstract Task Execute();
}

public class Deserialize : DeserializeTasks
{
    public required string Filepath { get; init; } //e.g @"AppData/Data/OutputXc3"
    public string FileNamePattern { get; set; } = "*"; //e.g $"Client{clientReference}.*.zip"

    public override async Task Execute()
    {
        var articlesTask = new DeserializeArticles()
        {
            Filepath = this.Filepath,
            FileNamePattern = this.FileNamePattern,
            FileName = $"Articles.json",
            Exporter = new ExportSQL()
        };

        await articlesTask.Execute();

        var linkagesTask = new DeserializeLinkages()
        {
            Filepath = this.Filepath,
            FileNamePattern = this.FileNamePattern,
            FileName = $"Linkages.json"
        };

        await linkagesTask.Execute();
    }
}
