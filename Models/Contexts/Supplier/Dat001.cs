using System;
using System.Collections.Generic;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class Dat001
{
    public long Id { get; set; }
    public string? BrandNo { get; set; }
    public string? TableNo { get; set; }
    public string? DataRelease { get; set; }
    public string? VersionDate { get; set; }
    public string? Full { get; set; }
    public string? ManNo { get; set; }
    public string? BrandName { get; set; }
    public string? RefDataVersion { get; set; }
    public string? Reserved { get; set; }
    public string? Format { get; set; }
    public string? DeleteFlag { get; set; }
}
