using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_330")]
public partial class In330
{
    [Key]
    [Column("MyId_330")]
    public long MyId330 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? GenArtNr { get; set; }
    public int? LfdNr { get; set; }
    public int? SortNr { get; set; }
    [StringLength(3)]
    public string? KritWert { get; set; }
    public int? MyFlag { get; set; }
}
