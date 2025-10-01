using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_124")]
public partial class In124
{
    [Key]
    [Column("MyId_124")]
    public long MyId124 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("KTypNr")]
    public long? KtypNr { get; set; }
    [Column("LKZ")]
    [StringLength(3)]
    public string? Lkz { get; set; }
    public int? Bjvon { get; set; }
    public int? Bjbis { get; set; }
    [Column("ccmSteuer")]
    public int? CcmSteuer { get; set; }
    public int? Lit { get; set; }
    public int? Zyl { get; set; }
    public int? Tueren { get; set; }
    public int? TankInhalt { get; set; }
    public int? Spannung { get; set; }
    [Column("ABS")]
    public int? Abs { get; set; }
    [Column("ASR")]
    public int? Asr { get; set; }
    public int? KrStoffArt { get; set; }
    public int? KatArt { get; set; }
    public int? GetrArt { get; set; }
    public int? BremsArt { get; set; }
    public int? BremsSys { get; set; }
    public int? MyFlag { get; set; }
}
