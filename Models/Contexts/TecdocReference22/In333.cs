using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_333")]
public partial class In333
{
    [Key]
    [Column("MyId_333")]
    public long MyId333 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? KritNr { get; set; }
    [StringLength(3)]
    public string? KritNrType { get; set; }
    public int? GenArtNr { get; set; }
    [StringLength(100)]
    public string? Constraint { get; set; }
}
