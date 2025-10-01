using System;
using System.Collections.Generic;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class Dat217
{
    public long Id { get; set; }
    public string? ArtNo { get; set; }
    public string? BrandNo { get; set; }
    public string? TableNo { get; set; }
    public string? SeqNo { get; set; }
    public string? DocNo { get; set; }
    public string? DocType { get; set; }
    public string? LangNo { get; set; }
    public string? CoordNo { get; set; }
    public string? DeleteFlag { get; set; }
}
