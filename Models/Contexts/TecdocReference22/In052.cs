using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_052")]
public partial class In052
{
    [Key]
    [Column("MyId_052")]
    public long MyId052 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? TabNr { get; set; }
    [StringLength(3)]
    public string? Key { get; set; }
    public long? BezNr { get; set; }
    public int? SortNr { get; set; }
    public int? Delete { get; set; }
    public int? MyFlag { get; set; }
}
