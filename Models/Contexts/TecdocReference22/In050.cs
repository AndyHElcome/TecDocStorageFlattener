using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_050")]
public partial class In050
{
    [Key]
    [Column("MyId_050")]
    public long MyId050 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? KritNr { get; set; }
    public long? BezNr { get; set; }
    [StringLength(1)]
    public string? Typ { get; set; }
    [StringLength(2)]
    public string? MaxLen { get; set; }
    [Column("OK-Artikel")]
    public int? OkArtikel { get; set; }
    public int? TabNr { get; set; }
    [Column("OK-NKW")]
    public int? OkNkw { get; set; }
    [Column("OK-PKW")]
    public int? OkPkw { get; set; }
    [Column("OK-MOTOR")]
    public int? OkMotor { get; set; }
    [Column("OK-Fahrerhaus")]
    public int? OkFahrerhaus { get; set; }
    [Column("Stücklisten-Criterion")]
    public int? StücklistenCriterion { get; set; }
    [Column("Zubehör-Criterion")]
    public int? ZubehörCriterion { get; set; }
    [Column("Mehrfach-verwendung")]
    public int? MehrfachVerwendung { get; set; }
    public long? BezNrAbk { get; set; }
    public long? BezNrEinheit { get; set; }
    public int? IntervallCriterion { get; set; }
    [Column("Nachfolge-Criterion")]
    public int? NachfolgeCriterion { get; set; }
    public int? Delete { get; set; }
    [Column("OK-Achse")]
    public int? OkAchse { get; set; }
    public int? MyFlag { get; set; }
}
