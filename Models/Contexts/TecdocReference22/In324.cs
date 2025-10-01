using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_324")]
public partial class In324
{
    [Key]
    [Column("MyId_324")]
    public long MyId324 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? BgNr { get; set; }
    public long? BezNr { get; set; }
    public int? MyFlag { get; set; }
}
