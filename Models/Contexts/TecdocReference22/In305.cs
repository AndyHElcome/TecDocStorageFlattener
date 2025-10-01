using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecDocStorageFlattener.Models.Contexts.TecdocReference22;

[Table("In_305")]
public partial class In305
{
    [Key]
    [Column("MyId_305")]
    public long MyId305 { get; set; }
    [Column("DLNr")]
    public int? Dlnr { get; set; }
    [Column("SA")]
    public int? Sa { get; set; }
    [Column("QS_Id")]
    public int? QsId { get; set; }
    public long? BezNr { get; set; }
    [StringLength(30)]
    public string? BildName { get; set; }
    public int? MyFlag { get; set; }
}
