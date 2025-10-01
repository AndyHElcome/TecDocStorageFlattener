using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_161")]
public partial class In161
{
    [Key]
    [Column("MyId_161")]
    public long MyId161 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? AtypNr { get; set; }
    [Column("LKZ")]
    [StringLength(3)]
    public string? Lkz { get; set; }
    public int? SortNr { get; set; }
    [StringLength(20)]
    public string? Muster { get; set; }
    public int? MyFlag { get; set; }
}
