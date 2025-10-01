using System;
using System.Collections.Generic;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class Dat400
{
    public long Id { get; set; }
    public string? ArtNo { get; set; }
    public string? BrandNo { get; set; }
    public string? TableNo { get; set; }
    public string? GenArtNo { get; set; }
    public string? LnkTargetType { get; set; }
    public string? LnkTargetNo { get; set; }
    public string? SeqNo { get; set; }
    public string? DeleteFlag { get; set; }
    public long? SourceApplicationReference { get; set; }
    public long? SourceProductReference { get; set; }
    public long? CustomSubProductIdentifier { get; set; }
    public long? IndexReference { get; set; }
    public long? VehicleReference { get; set; }
    public long? ExternalIndexReference { get; set; }
    public long? ExternalVehicleReference { get; set; }
    public long? AXSort { get; set; }
}
