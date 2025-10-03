using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TafLoader.Models.Tecdoc;
using TecDocStorageFlattener.Models.Contexts.Supplier;
using TecDocStorageFlattener.Models.Contexts.TecdocReference22;
using TecDocStorageFlattener.Models.Tecdoc;

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


    public static T020? GetLanguageFromSprachNr(this TecdocDbContext referenceData, short LangNo)
    {
        return referenceData.T020.FirstOrDefault(c => c.LangNo == LangNo);
    }
    public static T020? GetLanguageFromISOCode(this TecdocDbContext referenceData, string ISOCode)
    {
        return referenceData.T020.FirstOrDefault(c => c.IsoCode == ISOCode);
    }
    public static T010? GetCountryFromISOCode(this TecdocDbContext referenceData, string ISOCode)
    {
        return referenceData.T010.FirstOrDefault(c => c.IsoCode2 == ISOCode);
    }

}
