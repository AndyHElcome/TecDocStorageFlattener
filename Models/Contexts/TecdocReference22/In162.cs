using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_162")]
public partial class In162
{
    [Key]
    [Column("MyId_162")]
    public long MyId162 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? AtypNr { get; set; }
    public int? LfdNr { get; set; }
    public int? SortNr { get; set; }
    [StringLength(3)]
    public string? AchsPos { get; set; }
    public int? Radstand { get; set; }
    public int? MyFlag { get; set; }
}
