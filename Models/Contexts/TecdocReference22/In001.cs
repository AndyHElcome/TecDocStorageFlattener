using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_001")]
public partial class In001
{
    [Key]
    [Column("MyId_001")]
    public long MyId001 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? Version { get; set; }
    public int? Datum { get; set; }
    [Column("KZVoll")]
    public int? Kzvoll { get; set; }
    [Column("KHerNr")]
    public int? KherNr { get; set; }
    [StringLength(20)]
    public string? Marke { get; set; }
    public int? MyFlag { get; set; }
}
