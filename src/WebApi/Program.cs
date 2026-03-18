namespace Formica.WebApi;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddHealthChecks();

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.MapHealthChecks("/healthz");

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.MapFallbackToFile("index.html");

        await app.RunAsync();
    }
}
