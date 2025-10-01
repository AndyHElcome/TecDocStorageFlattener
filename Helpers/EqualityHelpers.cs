using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecDocStorageFlattener.Helpers;

public static class EqualityHelpers
{
    public static bool AreArraysEqual<T>(T[]? array1, T[]? array2)
    {
        if (array1 == null && array2 == null)
            return true;
        if (array1 == null || array2 == null)
            return false;
        if (array1.Length != array2.Length)
            return false;
        var set1 = new HashSet<T>(array1);
        var set2 = new HashSet<T>(array2);
        return set1.SetEquals(set2);
    }

    public static bool AreEnumerableEqual<T>(IEnumerable<T>? array1, IEnumerable<T>? array2)
    {
        if (array1 == null && array2 == null)
            return true;
        if (array1 == null || array2 == null)
            return false;
        if (array1.Count() != array2.Count())
            return false;
        var set1 = new HashSet<T>(array1);
        var set2 = new HashSet<T>(array2);
        return set1.SetEquals(set2);
    }

    public static bool AreHashSetEqual<T>(HashSet<T>? array1, HashSet<T>? array2)
    {
        if (array1 == null && array2 == null)
            return true;
        if (array1 == null || array2 == null)
            return false;
        if (array1.Count() != array2.Count())
            return false;
        return array1.SetEquals(array2);
    }
}
