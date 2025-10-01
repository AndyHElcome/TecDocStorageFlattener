using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_144")]
public partial class In144
{
    [Key]
    [Column("MyId_144")]
    public long MyId144 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("KTypNr")]
    public long? KtypNr { get; set; }
    public long? LbezNr1 { get; set; }
    public long? LbezNr2 { get; set; }
    public int? MyFlag { get; set; }
}
