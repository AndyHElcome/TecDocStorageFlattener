using System;
using System.Collections.Generic;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class Dat222
{
    public long Id { get; set; }
    public string? ArtNo { get; set; }
    public string? BrandNo { get; set; }
    public string? TableNo { get; set; }
    public string? LnkType { get; set; }
    public string? LnkVal { get; set; }
    public string? SeqNo { get; set; }
    public string? SortNo { get; set; }
    public string? AccArtNo { get; set; }
    public string? Quantity { get; set; }
    public string? AccGenArtNo { get; set; }
    public string? Reserved { get; set; }
    public string? TermNo { get; set; }
    public string? DeleteFlag { get; set; }
}
