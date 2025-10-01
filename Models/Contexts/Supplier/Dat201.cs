using System;
using System.Collections.Generic;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class Dat201
{
    public long Id { get; set; }
    public string? ArtNo { get; set; }
    public string? BrandNo { get; set; }
    public string? TableNo { get; set; }
    public string? Price { get; set; }
    public string? PrUnit { get; set; }
    public string? PrQuantUnit { get; set; }
    public string? ValidFrom { get; set; }
    public string? ValidTo { get; set; }
    public string? CountryCode { get; set; }
    public string? PrType { get; set; }
    public string? Reserved { get; set; }
    public string? CurCode { get; set; }
    public string? DiscGroup { get; set; }
    public string? Discount { get; set; }
    public string? DeleteFlag { get; set; }
}
