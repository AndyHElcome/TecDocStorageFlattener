using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_323")]
public partial class In323
{
    [Key]
    [Column("MyId_323")]
    public long MyId323 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? NartNr { get; set; }
    public long? BezNr { get; set; }
    public int? MyFlag { get; set; }
}
