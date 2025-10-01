using System;
using System.Collections.Generic;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class Dat211
{
    public long Id { get; set; }
    public string? ArtNo { get; set; }
    public string? BrandNo { get; set; }
    public string? TableNo { get; set; }
    public string? GenArtNo { get; set; }
    public string? DeleteFlag { get; set; }
}
