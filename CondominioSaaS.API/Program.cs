using CondominioSaaS.API.Endpoints;
using CondominioSaaS.Configurations.Configs;
using CondominioSaaS.Configurations.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddAppLogging();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddMemoryCache();
builder.Services.AddMediatRAndValidators();
builder.Services.AddRepositories();
builder.Services.AddRabbitMQEmailTokenServices(builder.Configuration);
builder.Services.AddAppCorsPolicy(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAppAuthorizationPolicies();
builder.Services.AddHealthChecks();
builder.Services.AddAppJsonOptions();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerAndSecurity();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok("healthy"));

await app.ApplyMigrationsWithRetryAsync();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});

app.UseAppMiddleware(app.Environment);
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

app.MapEnumsEndpoints();
app.MapImovelEndpoints();

app.Run();

public partial class Program { }
