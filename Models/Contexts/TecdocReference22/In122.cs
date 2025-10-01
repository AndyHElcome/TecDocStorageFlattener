using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_122")]
public partial class In122
{
    [Key]
    [Column("MyId_122")]
    public long MyId122 { get; set; }
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
    public int? Exclude { get; set; }
    public int? MyFlag { get; set; }
}
