using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_555")]
public partial class In555
{
    [Key]
    [Column("MyId_555")]
    public long MyId555 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("HerlDNr")]
    public int? HerlDnr { get; set; }
    [Column("LKZ")]
    public int? Lkz { get; set; }
    public int? Exclude { get; set; }
    public int? MyFlag { get; set; }
}
