using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_541")]
public partial class In541
{
    [Key]
    [Column("MyId_541")]
    public long MyId541 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("FHausNr")]
    public int? FhausNr { get; set; }
    [Column("KHerNr")]
    public int? KherNr { get; set; }
    [Column("KModNr")]
    public int? KmodNr { get; set; }
    [StringLength(30)]
    public string? Baumuster { get; set; }
    [Column("LBezNr")]
    public long? LbezNr { get; set; }
    [StringLength(21)]
    public string? Reserviert { get; set; }
    public int? Size { get; set; }
    [Column("BJvon")]
    public int? Bjvon { get; set; }
    [Column("BJbis")]
    public int? Bjbis { get; set; }
    public int? Length { get; set; }
    public int? Height { get; set; }
    public int? Width { get; set; }
    public int? Delete { get; set; }
    public int? MyFlag { get; set; }
}
