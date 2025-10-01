using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_540")]
public partial class In540
{
    [Key]
    [Column("MyId_540")]
    public long MyId540 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("NTypNr")]
    public long? NtypNr { get; set; }
    [Column("NTypSubNr")]
    public int? NtypSubNr { get; set; }
    public int? LfdNr { get; set; }
    public int? Volt { get; set; }
    [Column("LKZ")]
    [StringLength(3)]
    public string? Lkz { get; set; }
    public int? Exclude { get; set; }
    public int? MyFlag { get; set; }
}
