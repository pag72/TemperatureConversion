using Microsoft.EntityFrameworkCore;
using TemperatureAPI.Shared.Models;

namespace TemperatureAPI.Data
{
    public class TemperatureDb : DbContext
    {
        public TemperatureDb(DbContextOptions<TemperatureDb> options)
            : base(options) { }

        public DbSet<TemperatureConversion> TemperatureConversions => Set<TemperatureConversion>();
    }
}