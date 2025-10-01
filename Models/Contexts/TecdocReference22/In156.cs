using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_156")]
public partial class In156
{
    [Key]
    [Column("MyId_156")]
    public long MyId156 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? MotNr { get; set; }
    [Column("LKZ")]
    [StringLength(3)]
    public string? Lkz { get; set; }
    public int? MyFlag { get; set; }
}
