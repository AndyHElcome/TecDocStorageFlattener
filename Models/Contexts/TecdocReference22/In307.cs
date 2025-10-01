using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_307")]
public partial class In307
{
    [Key]
    [Column("MyId_307")]
    public long MyId307 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? TreeTypNr { get; set; }
    [Column("QS_Id")]
    public int? QsId { get; set; }
    [Column("Node_ID")]
    public int? NodeId { get; set; }
    public int? SortNr { get; set; }
    public int? MyFlag { get; set; }
}
