using System;
using System.Collections.Generic;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class Dat410
{
    public long Id { get; set; }
    public string? ArtNo { get; set; }
    public string? BrandNo { get; set; }
    public string? TableNo { get; set; }
    public string? GenArtNo { get; set; }
    public string? LnkTargetType { get; set; }
    public string? LnkTargetNo { get; set; }
    public string? SeqNo { get; set; }
    public string? SortNo { get; set; }
    public string? CritNo { get; set; }
    public string? CritVal { get; set; }
    public string? FirstPage { get; set; }
    public string? CountryCode { get; set; }
    public string? Exclude { get; set; }
    public string? DeleteFlag { get; set; }
}
