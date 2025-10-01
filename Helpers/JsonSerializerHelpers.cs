
namespace TecDocStorageFlattener.Helpers;
public static class JsonSerializerHelpers
    {
        public static readonly System.Text.Json.JsonSerializerOptions JsonSerializerOptions = new()
        {
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            ReadCommentHandling = System.Text.Json.JsonCommentHandling.Skip,
            WriteIndented = true,
            PropertyNamingPolicy = null,
        };
    }
