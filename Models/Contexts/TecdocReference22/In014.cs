using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_014")]
public partial class In014
{
    [Key]
    [Column("MyId_014")]
    public long MyId014 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? DokumentenArt { get; set; }
    public long? BezNr { get; set; }
    [StringLength(3)]
    public string? Extension { get; set; }
    public int? MyFlag { get; set; }
}
