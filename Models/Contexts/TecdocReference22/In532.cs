using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_532")]
public partial class In532
{
    [Key]
    [Column("MyId_532")]
    public long MyId532 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("NTypNr")]
    public long? NtypNr { get; set; }
    [Column("KModNr")]
    public int? KmodNr { get; set; }
    public int? Sort { get; set; }
    public long? LbezNr { get; set; }
    [Column("BJvon")]
    public int? Bjvon { get; set; }
    [Column("BJbis")]
    public int? Bjbis { get; set; }
    public int? Bauart { get; set; }
    public int? Motart { get; set; }
    [Column("KWvon")]
    public int? Kwvon { get; set; }
    [Column("KWbis")]
    public int? Kwbis { get; set; }
    [Column("PSvon")]
    public int? Psvon { get; set; }
    [Column("PSbis")]
    public int? Psbis { get; set; }
    public int? CcmTech { get; set; }
    public int? Tonnage { get; set; }
    public int? Achsconfig { get; set; }
    public int? Delete { get; set; }
    public int? MyFlag { get; set; }
}
