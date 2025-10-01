using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_100")]
public partial class In100
{
    [Key]
    [Column("MyId_100")]
    public long MyId100 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? HerNr { get; set; }
    [Column("HKZ")]
    [StringLength(10)]
    public string? Hkz { get; set; }
    [Column("LBezNr")]
    public long? LbezNr { get; set; }
    [Column("PKW")]
    public int? Pkw { get; set; }
    [Column("NKW")]
    public int? Nkw { get; set; }
    [Column("VGL")]
    public int? Vgl { get; set; }
    public int? Achse { get; set; }
    public int? Motor { get; set; }
    public int? Getriebe { get; set; }
    public int? Delete { get; set; }
    public int? MyFlag { get; set; }
}
