using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_327")]
public partial class In327
{
    [Key]
    [Column("MyId_327")]
    public long MyId327 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? GenArtNr { get; set; }
    public int? LfdNr { get; set; }
    public int? SprachNr { get; set; }
    [StringLength(60)]
    public string? Bez { get; set; }
    public int? MyFlag { get; set; }
}
