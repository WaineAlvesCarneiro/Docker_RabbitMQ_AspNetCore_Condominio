using System.Text.Json;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;

namespace CondominioSaaS.Configurations.Configs;

public static class JsonExtensions
{
	public static void ConfigureJsonDefaults(this JsonSerializerOptions options)
	{
		options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
		options.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
		// Outras configurações globais
	}

	public static IServiceCollection AddAppJsonOptions(this IServiceCollection services)
	{
		// Minimal APIs
		services.Configure<JsonOptions>(options =>
		{
			options.SerializerOptions.ConfigureJsonDefaults();
		});

		// Controllers
		services.AddControllers()
			.AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.ConfigureJsonDefaults();
			});

		return services;
	}
}
