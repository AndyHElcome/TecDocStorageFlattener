using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_120")]
public partial class In120
{
    [Key]
    [Column("MyId_120")]
    public long MyId120 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("KTypNr")]
    public long? KtypNr { get; set; }
    public long? LbezNr { get; set; }
    [Column("KModNr")]
    public int? KmodNr { get; set; }
    public int? SortNr { get; set; }
    public int? Bjvon { get; set; }
    public int? Bjbis { get; set; }
    [Column("KW")]
    public int? Kw { get; set; }
    [Column("PS")]
    public int? Ps { get; set; }
    [Column("ccmSteuer")]
    public int? CcmSteuer { get; set; }
    [Column("ccmTech")]
    public int? CcmTech { get; set; }
    public int? Lit { get; set; }
    public int? Zyl { get; set; }
    public int? Tueren { get; set; }
    public int? TankInhalt { get; set; }
    public int? Spannung { get; set; }
    [Column("ABS")]
    public int? Abs { get; set; }
    [Column("ASR")]
    public int? Asr { get; set; }
    public int? MotArt { get; set; }
    public int? FuelMixture { get; set; }
    public int? AntrArt { get; set; }
    public int? BremsArt { get; set; }
    public int? BremsSys { get; set; }
    [Column("Ventile/Brennraum")]
    public int? VentileBrennraum { get; set; }
    public int? KrStoffArt { get; set; }
    public int? KatArt { get; set; }
    public int? GetrArt { get; set; }
    public int? AufbauArt { get; set; }
    public int? Delete { get; set; }
    public int? MyFlag { get; set; }
}
