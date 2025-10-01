using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_140")]
public partial class In140
{
    [Key]
    [Column("MyId_140")]
    public long MyId140 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("KModNr")]
    public int? KmodNr { get; set; }
    public long? LbezNr1 { get; set; }
    public long? LbezNr2 { get; set; }
    public int? MyFlag { get; set; }
}
