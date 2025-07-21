using System.Reflection;

namespace HelloBlazor.App.Helpers;

public static class QueryStringHelper
{
    public static string ToQueryString(object obj)
    {
        if (obj == null)
            return string.Empty;

        var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var queryParams = new List<string>();

        foreach (var prop in properties)
        {
            var value = prop.GetValue(obj);
            if (value == null) continue;

            var key = Uri.EscapeDataString(prop.Name);
            var val = Uri.EscapeDataString(value.ToString()!);

            queryParams.Add($"{key}={val}");
        }

        return string.Join("&", queryParams);
    }
}
