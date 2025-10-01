using System;
using System.Collections.Generic;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class Dat203
{
    public long Id { get; set; }
    public string? ArtNo { get; set; }
    public string? BrandNo { get; set; }
    public string? TableNo { get; set; }
    public string? ManNo { get; set; }
    public string? CountryCode { get; set; }
    public string? RefNo { get; set; }
    public string? Exclude { get; set; }
    public string? SortNo { get; set; }
    public string? Additive { get; set; }
    public string? ReferenceInfo { get; set; }
    public string? DeleteFlag { get; set; }
}
