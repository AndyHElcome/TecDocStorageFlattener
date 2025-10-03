using System.Collections.Generic;

namespace TecDocStorageFlattener.Models
{
    public class DefinitionTableJson
    {
        public List<DefinitionTable>? DefinitionTable { get; set; }
    }
    public class DefinitionTable
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<DefinitionTableColumns>? Column { get; set; }
    }

    public class DefinitionTableColumns
    {
        public string? NameInTable { get; set; }
        public string? Name { get; set; }
        public string? Pos { get; set; }
        public string? Length { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Relation { get; set; }

    }
}
