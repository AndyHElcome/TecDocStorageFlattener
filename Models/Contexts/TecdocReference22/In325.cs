using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_325")]
public partial class In325
{
    [Key]
    [Column("MyId_325")]
    public long MyId325 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? VerwNr { get; set; }
    public long? BezNr { get; set; }
    public int? MyFlag { get; set; }
}
