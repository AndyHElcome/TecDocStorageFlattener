using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_146")]
public partial class In146
{
    [Key]
    [Column("MyId_146")]
    public long MyId146 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? AufbauArt { get; set; }
    public int? KmodNr { get; set; }
    public long? LbezNr { get; set; }
    public int? MyFlag { get; set; }
}
