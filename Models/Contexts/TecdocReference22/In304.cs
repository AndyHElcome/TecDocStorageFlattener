using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_304")]
public partial class In304
{
    [Key]
    [Column("MyId_304")]
    public long MyId304 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("Node_ID")]
    public int? NodeId { get; set; }
    public int? GenArtNr { get; set; }
    public int? SortNr { get; set; }
    public int? KritNr { get; set; }
    [StringLength(20)]
    public string? KritWert { get; set; }
    public int? MyFlag { get; set; }
}
