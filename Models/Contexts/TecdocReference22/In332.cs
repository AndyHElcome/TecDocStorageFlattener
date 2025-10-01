using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_332")]
public partial class In332
{
    [Key]
    [Column("MyId_332")]
    public long MyId332 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? GenArtNr { get; set; }
    public int? KritNr { get; set; }
    [StringLength(3)]
    public string? KritWert { get; set; }
}
