using System;
using System.Collections.Generic;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class Dat212
{
    public long Id { get; set; }
    public string? ArtNo { get; set; }
    public string? BrandNo { get; set; }
    public string? TableNo { get; set; }
    public string? CountryCode { get; set; }
    public string? QuantityUnit { get; set; }
    public string? QuantityPerUnit { get; set; }
    public string? ArtStat { get; set; }
    public string? StatusDat { get; set; }
    public string? DeleteFlag { get; set; }
}
