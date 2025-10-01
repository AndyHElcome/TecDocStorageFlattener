using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_121")]
public partial class In121
{
    [Key]
    [Column("MyId_121")]
    public long MyId121 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("KBANr")]
    [StringLength(7)]
    public string? Kbanr { get; set; }
    [Column("KTypNr")]
    public long? KtypNr { get; set; }
    public int? AufbauArt { get; set; }
    [Column("ABENr")]
    [StringLength(25)]
    public string? Abenr { get; set; }
    [Column("ABEvon")]
    public int? Abevon { get; set; }
    [StringLength(25)]
    public string? StatHer { get; set; }
    [StringLength(25)]
    public string? StatTyp { get; set; }
    public int? MyFlag { get; set; }
}
