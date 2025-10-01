using System;
using System.Collections.Generic;

namespace TecDocStorageFlattener.Models.Contexts.Supplier;

public partial class Dat035
{
    public long Id { get; set; }
    public string? Reserved { get; set; }
    public string? BrandNo { get; set; }
    public string? TableNo { get; set; }
    public string? TxtModNo { get; set; }
    public string? LangNo { get; set; }
    public string? Fixed { get; set; }
    public string? SeqNo { get; set; }
    public string? Text { get; set; }
    public string? DeleteFlag { get; set; }
}
