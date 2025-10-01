using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_147")]
public partial class In147
{
    [Key]
    [Column("MyId_147")]
    public long MyId147 { get; set; }
    [StringLength(22)]
    public string? Reserviert { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    public int? AntrArt { get; set; }
    [Column("KTypNr")]
    public long? KtypNr { get; set; }
    public long? LbezNr { get; set; }
    public int? MyFlag { get; set; }
}
