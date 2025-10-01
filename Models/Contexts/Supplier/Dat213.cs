using System;
using System.Collections.Generic;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class Dat213
{
    public long Id { get; set; }
    public string? ArtNo { get; set; }
    public string? BrandNo { get; set; }
    public string? TableNo { get; set; }
    public string? CountryCode { get; set; }
    public string? SortNo { get; set; }
    public string? CritNo { get; set; }
    public string? CritVal { get; set; }
    public string? FirstPage { get; set; }
    public string? Exclude { get; set; }
}
