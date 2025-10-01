using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecDocStorageFlattener.Models.Contexts.TecdocReference22;

namespace TecDocStorageFlattener.Helpers;

public static class ReferenceQueryHelpers
{
    public static In020? GetLanguageFromSprachNr(this TecdocReference22DbContext referenceData, int SprachNr)
    {
        return referenceData.In020s.FirstOrDefault(c => c.SprachNr == SprachNr);
    }
    public static In020? GetLanguageFromSprachNr(this TecdocReference22DbContext referenceData, string SprachNr)
    {
        return referenceData.In020s.FirstOrDefault(c => c.SprachNr.ToString() == SprachNr);
    }
    public static In020? GetLanguageFromISOCode(this TecdocReference22DbContext referenceData, string ISOCode)
    {
        return referenceData.In020s.FirstOrDefault(c => c.Isocode == ISOCode);
    }

}
