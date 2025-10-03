using System.Reflection;
using TecDocStorageFlattener.Models.Tecdoc;

namespace TecDocStorageFlattener.Helpers;

public static class AttributesExtensions
{
    public static IEnumerable<PropertyInfo> AllAttributes<T>(this object obj, string name)
    {
        var allProperties = obj.GetType().GetProperties()
        .Where(_ => _.GetCustomAttributes(typeof(T), true).Length >= 1 && _.Name == name);
        return allProperties;
    }

    public static IEnumerable<PropertyInfo> AllTecdocFieldAttribute(this Type obj, string name)
    {
        var allProperties = obj.GetProperties()
        .Where(_ => _.GetCustomAttributes<TecdocFieldAttribute>().FirstOrDefault(c => c.Name == name) != default);
        return allProperties;
    }

    public static IEnumerable<PropertyInfo> AllTecdocFieldAttribute<T>(this T obj, string name)
    {
        var allProperties = obj.GetType().GetProperties()
        .Where(_ => _.GetCustomAttributes<TecdocFieldAttribute>().FirstOrDefault(c => c.Name == name) != default);
        return allProperties;
    }

    public static IEnumerable<PropertyInfo> AllAttributes<T>(this object obj)
    {
        var allProperties = obj.GetType().GetProperties()
        .Where(_ => _.GetCustomAttributes(typeof(T), true).Length >= 1);
        return allProperties;
    }

    public static IEnumerable<PropertyInfo> AllAttributes<T>(this Type obj)
    {
        var allProperties = obj.GetType().GetProperties()
        .Where(_ => _.GetCustomAttributes(typeof(T), true).Length >= 1);
        return allProperties;
    }

    public static T ReadAttribute<T>(this PropertyInfo propertyInfo)
    {
        var returnType = propertyInfo.GetCustomAttributes(typeof(T), true)
        .Cast<T>().FirstOrDefault();
        return returnType;
    }
}