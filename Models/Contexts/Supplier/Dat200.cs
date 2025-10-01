using System;
using System.Collections.Generic;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class Dat200
{
    public long Id { get; set; }
    public string? ArtNo { get; set; }
    public string? BrandNo { get; set; }
    public string? TableNo { get; set; }
    public string? TermNo { get; set; }
    public string? Selferv { get; set; }
    public string? MatCert { get; set; }
    public string? Remanufact { get; set; }
    public string? Accesory { get; set; }
    public string? BatchSize1 { get; set; }
    public string? BatchSize2 { get; set; }
    public string? DeleteFlag { get; set; }
}
