using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_031")]
public partial class In031
{
    [Key]
    [Column("MyId_031")]
    public long MyId031 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public long? BezNr { get; set; }
    public int? SprachNr { get; set; }
    [StringLength(60)]
    public string? Bez { get; set; }
    public int? MyFlag { get; set; }
}
