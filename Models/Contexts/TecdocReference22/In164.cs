using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_164")]
public partial class In164
{
    [Key]
    [Column("MyId_164")]
    public long MyId164 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public long? NtypNr { get; set; }
    public int? LfdNr { get; set; }
    public int? SortNr { get; set; }
    [Column("ATypNr")]
    public int? AtypNr { get; set; }
    public int? AchsPos { get; set; }
    [Column("BJvon")]
    public int? Bjvon { get; set; }
    [Column("BJbis")]
    public int? Bjbis { get; set; }
    [Column("LKZ")]
    [StringLength(3)]
    public string? Lkz { get; set; }
    public int? Exclude { get; set; }
    public int? MyFlag { get; set; }
}
