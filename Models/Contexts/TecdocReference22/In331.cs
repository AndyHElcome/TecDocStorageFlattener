using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_331")]
public partial class In331
{
    [Key]
    [Column("MyId_331")]
    public long MyId331 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? GenArtNr { get; set; }
    public int? SortNr { get; set; }
    public int? KritNr { get; set; }
    public byte? Usage { get; set; }
    public bool? OnlyArticle { get; set; }
}
