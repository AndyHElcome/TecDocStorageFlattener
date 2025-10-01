using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_340")]
public partial class In340
{
    [Key]
    [Column("MyId_340")]
    public long MyId340 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? GenArtNr { get; set; }
    [StringLength(3)]
    public string? EngineTypeKey { get; set; }
}
