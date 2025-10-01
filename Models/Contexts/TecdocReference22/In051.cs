using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_051")]
public partial class In051
{
    [Key]
    [Column("MyId_051")]
    public long MyId051 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? TabNr { get; set; }
    public long? BezNr { get; set; }
    [StringLength(1)]
    public string? TabTyp { get; set; }
    public int? Delete { get; set; }
    public int? MyFlag { get; set; }
}
