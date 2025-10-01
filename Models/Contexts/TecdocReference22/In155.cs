using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_155")]
public partial class In155
{
    [Key]
    [Column("MyId_155")]
    public long MyId155 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("MHerNr")]
    public int? MherNr { get; set; }
    public int? MotNr { get; set; }
    [Column("MCode")]
    [StringLength(60)]
    public string? Mcode { get; set; }
    [Column("BJvon")]
    public int? Bjvon { get; set; }
    [Column("BJbis")]
    public int? Bjbis { get; set; }
    [Column("kWvon")]
    public int? KWvon { get; set; }
    [Column("kWbis")]
    public int? KWbis { get; set; }
    [Column("PSvon")]
    public int? Psvon { get; set; }
    [Column("PSbis")]
    public int? Psbis { get; set; }
    public int? Ventile { get; set; }
    public int? Zyl { get; set; }
    public int? VerdichtV { get; set; }
    public int? VerdichtB { get; set; }
    public int? DrehmV { get; set; }
    public int? DrehmB { get; set; }
    [Column("ccmSteuerV")]
    public int? CcmSteuerV { get; set; }
    [Column("ccmSteuerB")]
    public int? CcmSteuerB { get; set; }
    [Column("ccmTechV")]
    public int? CcmTechV { get; set; }
    [Column("ccmTechB")]
    public int? CcmTechB { get; set; }
    public int? LitSteuerV { get; set; }
    public int? LitSteuerB { get; set; }
    public int? LitTechV { get; set; }
    public int? LitTechB { get; set; }
    public int? MotVerw { get; set; }
    public int? MotBauForm { get; set; }
    public int? KrStoffArt { get; set; }
    public int? KrStoffAuf { get; set; }
    public int? MotBeatm { get; set; }
    public int? UminKwV { get; set; }
    public int? UminKwB { get; set; }
    public int? UminDrehmV { get; set; }
    public int? UminDrehmB { get; set; }
    public int? Kurbel { get; set; }
    public int? Bohrung { get; set; }
    public int? Hub { get; set; }
    public int? Motorart { get; set; }
    public int? Abgasnorm { get; set; }
    public int? ZylBauForm { get; set; }
    public int? MotSteuer { get; set; }
    public int? VentilSteuer { get; set; }
    public int? KuehlArt { get; set; }
    [StringLength(30)]
    public string? VkBez { get; set; }
    public int? Exclude { get; set; }
    public int? Delete { get; set; }
    public int? MyFlag { get; set; }
}
