using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_301")]
public partial class In301
{
    [Key]
    [Column("MyId_301")]
    public long MyId301 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("Node_ID")]
    public int? NodeId { get; set; }
    public int? TreeTypNr { get; set; }
    public int? Stufe { get; set; }
    [Column("Node_Parent_ID")]
    public int? NodeParentId { get; set; }
    public int? SortNr { get; set; }
    public long? BezNr { get; set; }
    [Column("WertOK")]
    public int? WertOk { get; set; }
    public int? MyFlag { get; set; }
}
