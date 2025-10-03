namespace TecDocStorageFlattener.Helpers;

public static class TemplateHelpers
{
    public static bool HandleTemplateParameter(ref string template, string parameter, int parameterIndex)
    {
        parameter = "{" + parameter;
        if (template.Contains(parameter, StringComparison.OrdinalIgnoreCase))
        {
            template = template.Replace(parameter, "{" + parameterIndex, StringComparison.OrdinalIgnoreCase);
            return true;
        }
        else
        {
            return false;
        }
    }
}



