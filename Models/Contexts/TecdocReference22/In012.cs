using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_012")]
public partial class In012
{
    [Key]
    [Column("MyId_012")]
    public long MyId012 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("LBezNr")]
    public long? LbezNr { get; set; }
    [Column("LKZ")]
    [StringLength(3)]
    public string? Lkz { get; set; }
    public int? SprachNr { get; set; }
    [StringLength(60)]
    public string? Bez { get; set; }
    public int? MyFlag { get; set; }
}
