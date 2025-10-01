using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_320")]
public partial class In320
{
    [Key]
    [Column("MyId_320")]
    public long MyId320 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? GenArtNr { get; set; }
    public int? NartNr { get; set; }
    public int? BgNr { get; set; }
    public int? VerwNr { get; set; }
    public long? BezNr { get; set; }
    [Column("OK_PKW")]
    public int? OkPkw { get; set; }
    [Column("OK-NKW")]
    public int? OkNkw { get; set; }
    [Column("OK-Motor")]
    public int? OkMotor { get; set; }
    [Column("OK-Universal")]
    public int? OkUniversal { get; set; }
    [Column("OK-FZGUnab")]
    public int? OkFzgunab { get; set; }
    public int? Delete { get; set; }
    [Column("OK-Achse")]
    public int? OkAchse { get; set; }
    public int? MyFlag { get; set; }
}
