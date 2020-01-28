using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VetMedData.NET.DAL
{
    public class DesignTimeContextFactory:IDesignTimeDbContextFactory<VetMedDbContext> 
    {
        public VetMedDbContext CreateDbContext(string[] args)
        {

            var port = Environment.GetEnvironmentVariable("DB_PORT")??"1433";
            var server = Environment.GetEnvironmentVariable("DB_SERVER");
            var database = Environment.GetEnvironmentVariable("DB_NAME")??"VetMedData.NET";
            var username = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASS");

            var connectionString =
                $"Server=tcp:{server},{port};Database={database};User ID={username};Password={password};Encrypt=true;Connection Timeout=30;";
            var optionsBuilder = new DbContextOptionsBuilder<VetMedDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new VetMedDbContext(optionsBuilder.Options);
        }
    }
}
