using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_143")]
public partial class In143
{
    [Key]
    [Column("MyId_143")]
    public long MyId143 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? KmodNr { get; set; }
    [Column("LKZ")]
    [StringLength(3)]
    public string? Lkz { get; set; }
    public int? SortNr { get; set; }
    [StringLength(10)]
    public string? Muster { get; set; }
    public int? MyFlag { get; set; }
}
