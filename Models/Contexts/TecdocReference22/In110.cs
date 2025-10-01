using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_110")]
public partial class In110
{
    [Key]
    [Column("MyId_110")]
    public long MyId110 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("KModNr")]
    public int? KmodNr { get; set; }
    [Column("LBezNr")]
    public long? LbezNr { get; set; }
    public int? HerNr { get; set; }
    public int? SortNr { get; set; }
    public int? Bjvon { get; set; }
    [Column("BJBis")]
    public int? Bjbis { get; set; }
    [Column("PKW")]
    public int? Pkw { get; set; }
    [Column("NKW")]
    public int? Nkw { get; set; }
    public int? Achse { get; set; }
    public int? Delete { get; set; }
    public int? MyFlag { get; set; }
}
