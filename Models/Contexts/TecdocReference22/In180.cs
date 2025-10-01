using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_180")]
public partial class In180
{
    [Key]
    [Column("MyId_180")]
    public long MyId180 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public short LinkageTargetType { get; set; }
    public int LinkageTargetNo { get; set; }
    public short PowerOutputTypeKey { get; set; }
    public short FuelTypeKey { get; set; }
    public int PowerKw { get; set; }
}
