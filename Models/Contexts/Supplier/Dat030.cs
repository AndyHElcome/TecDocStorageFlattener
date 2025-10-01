using System;
using System.Collections.Generic;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class Dat030
{
    public long Id { get; set; }
    public string? Reserved { get; set; }
    public string? BrandNo { get; set; }
    public string? TableNo { get; set; }
    public string? TermNo { get; set; }
    public string? LangNo { get; set; }
    public string? Term { get; set; }
    public string? DeleteFlag { get; set; }
}
