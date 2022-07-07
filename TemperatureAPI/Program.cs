using Microsoft.EntityFrameworkCore;
using TemperatureAPI;
using TemperatureAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Blazor Minimal Web API Temperature Converter", Version = "v1" });
});

builder.Services.AddDbContext<TemperatureDb>(opt => opt.UseInMemoryDatabase("TemperatureHistory"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(swaggerUIOptions =>
    {
        swaggerUIOptions.DocumentTitle = "Blazor Minimal Web API Temperature Converter";
        swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal Web API serving the TemperatureConversion model");
        swaggerUIOptions.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();
app.MapTemperatureEndPoints();

app.Run();