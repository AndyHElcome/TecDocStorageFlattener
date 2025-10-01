using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_020")]
public partial class In020
{
    [Key]
    [Column("MyId_020")]
    public long MyId020 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? SprachNr { get; set; }
    public long? BezNr { get; set; }
    [Column("ISOCode")]
    [StringLength(2)]
    public string? Isocode { get; set; }
    [Column("Codepage")]
    public int? CodePage { get; set; }
    public int? MyFlag { get; set; }
}
