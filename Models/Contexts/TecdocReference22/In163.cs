using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_163")]
public partial class In163
{
    [Key]
    [Column("MyId_163")]
    public long MyId163 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? AtypNr { get; set; }
    public int? LfdNr { get; set; }
    public int? Bremsengröße { get; set; }
    [StringLength(20)]
    public string? Bezeichnung { get; set; }
    public int? MyFlag { get; set; }
}
