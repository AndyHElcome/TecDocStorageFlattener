using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_145")]
public partial class In145
{
    [Key]
    [Column("MyId_145")]
    public long MyId145 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("KTypNr")]
    public long? KtypNr { get; set; }
    [Column("LKZ")]
    [StringLength(3)]
    public string? Lkz { get; set; }
    public int? SortNr { get; set; }
    [StringLength(10)]
    public string? Muster { get; set; }
    public int? MyFlag { get; set; }
}
