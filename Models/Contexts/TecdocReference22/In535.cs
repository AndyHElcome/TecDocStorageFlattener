using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_535")]
public partial class In535
{
    [Key]
    [Column("MyId_535")]
    public long MyId535 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("NTypNr")]
    public long? NtypNr { get; set; }
    [Column("NTypSubNr")]
    public int? NtypSubNr { get; set; }
    public int? SortNr { get; set; }
    [StringLength(60)]
    public string? Bez { get; set; }
    [Column("BJvon")]
    public int? Bjvon { get; set; }
    [Column("BJbis")]
    public int? Bjbis { get; set; }
    public int? MyFlag { get; set; }
}
