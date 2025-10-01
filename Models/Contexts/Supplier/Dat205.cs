using System;
using System.Collections.Generic;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class Dat205
{
    public long Id { get; set; }
    public string? ArtNo { get; set; }
    public string? BrandNo { get; set; }
    public string? TableNo { get; set; }
    public string? PartGenArtNo { get; set; }
    public string? SeqNo { get; set; }
    public string? PartNo { get; set; }
    public string? Quantity { get; set; }
    public string? DeleteFlag { get; set; }
}
