using CondominioSaaS.Configurations.Converters;
using System.Text.Json;

namespace CondominioSaaS.Configurations.Configurations;

public static class JsonExtensions
{
    public static void ConfigureJsonDefaults(this JsonSerializerOptions options)
    {
        options.Converters.Add(new JsonDateOnlyConverter());
        //options.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter()); esse removi pois gerava erro no frontend que estava em .
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    }
}
