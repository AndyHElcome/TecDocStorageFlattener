using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_554")]
public partial class In554
{
    [Key]
    [Column("MyId_554")]
    public long MyId554 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("HerIDNr")]
    public int? HerIdNr { get; set; }
    public int? HerNr { get; set; }
    [Column("HerID")]
    [StringLength(20)]
    public string? HerId { get; set; }
    public int? MyFlag { get; set; }
}
