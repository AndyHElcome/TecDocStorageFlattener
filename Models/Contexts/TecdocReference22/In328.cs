using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_328")]
public partial class In328
{
    [Key]
    [Column("MyId_328")]
    public long MyId328 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? GenArtNr { get; set; }
    public int? LfdNr { get; set; }
    [Column("LKZ")]
    [StringLength(3)]
    public string? Lkz { get; set; }
    public int? KritNr { get; set; }
    public int? Only210 { get; set; }
    public int? Only400 { get; set; }
    public int? Exclude { get; set; }
    public int? MyFlag { get; set; }
}
