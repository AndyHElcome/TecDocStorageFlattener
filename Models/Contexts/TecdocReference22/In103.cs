using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_103")]
public partial class In103
{
    [Key]
    [Column("MyId_103")]
    public long MyId103 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("KBANr")]
    public int? Kbanr { get; set; }
    public int? HerNr { get; set; }
    public int? MyFlag { get; set; }
}
