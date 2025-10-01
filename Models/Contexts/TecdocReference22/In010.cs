using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_010")]
public partial class In010
{
    [Key]
    [Column("MyId_010")]
    public long MyId010 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("LKZ")]
    [StringLength(3)]
    public string? Lkz { get; set; }
    public long? BezNr { get; set; }
    [StringLength(1)]
    public string? Verkehr { get; set; }
    public int? WarNr { get; set; }
    [Column("WKZ")]
    [StringLength(3)]
    public string? Wkz { get; set; }
    public long? WarBezNr { get; set; }
    [StringLength(5)]
    public string? Vorwahl { get; set; }
    public int? IstGruppe { get; set; }
    [Column("ISOCode2")]
    [StringLength(2)]
    public string? Isocode2 { get; set; }
    [Column("ISOCode3")]
    [StringLength(3)]
    public string? Isocode3 { get; set; }
    [Column("ISOCodeNr")]
    public int? IsocodeNr { get; set; }
    public int? MyFlag { get; set; }
}
