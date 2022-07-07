using Microsoft.EntityFrameworkCore;
using TemperatureAPI.Data;
using TemperatureAPI.Helpers;
using TemperatureAPI.Shared.Models;

namespace TemperatureAPI
{
	public static class TemperatureEndPoints
	{
		public static void MapTemperatureEndPoints(this WebApplication app)
		{
            app.MapGet("/historicaltemperatures", async (TemperatureDb db) => await db.TemperatureConversions.ToListAsync());

            app.MapGet("/convertfrom/{scale}/{temperature}", (string scale, double temperature, TemperatureDb db) => 
            {
                try
                {
                    return Results.Ok(TemperatureConverter.ConvertTemperature(scale, temperature));
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });

            app.MapPost("/savetemperatureconversion", async (TemperatureDb db, TemperatureConversion temperatureConversion) =>
            {
                db.TemperatureConversions.Add(temperatureConversion);
                await db.SaveChangesAsync();
                return Results.Created($"/savetemperatureconversion/{temperatureConversion.Id}", temperatureConversion);
            });
        }
    }
}

