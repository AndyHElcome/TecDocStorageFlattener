using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_534")]
public partial class In534
{
    [Key]
    [Column("MyId_534")]
    public long MyId534 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("NTypNr")]
    public long? NtypNr { get; set; }
    [Column("LKZ")]
    [StringLength(3)]
    public string? Lkz { get; set; }
    [Column("BJvon")]
    public int? Bjvon { get; set; }
    [Column("BJbis")]
    public int? Bjbis { get; set; }
    public int? MyFlag { get; set; }
}
