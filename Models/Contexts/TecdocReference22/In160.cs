using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_160")]
public partial class In160
{
    [Key]
    [Column("MyId_160")]
    public long MyId160 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("ATypNr")]
    public int? AtypNr { get; set; }
    [StringLength(30)]
    public string? Bezeichnung { get; set; }
    public int? KmodNr { get; set; }
    public int? SortNr { get; set; }
    public int? Bjvon { get; set; }
    public int? Bjbis { get; set; }
    public int? AchsArt { get; set; }
    public int? Ausführung { get; set; }
    public int? BremsAusf { get; set; }
    public int? Achskörper { get; set; }
    public int? ZulLastVon { get; set; }
    public int? ZulLastBis { get; set; }
    public int? RadBefestigung { get; set; }
    public int? Spurweite { get; set; }
    [StringLength(20)]
    public string? Nabensystem { get; set; }
    [Column("Fahrhöhe von")]
    public int? FahrhöheVon { get; set; }
    [Column("Fahrhöhe bis")]
    public int? FahrhöheBis { get; set; }
    public int? Delete { get; set; }
    public int? MyFlag { get; set; }
}
