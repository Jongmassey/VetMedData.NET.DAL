using Microsoft.EntityFrameworkCore;
using VetMedData.NET.Model;

namespace VetMedData.NET.DAL
{
    public class VetMedDbContext :DbContext
    {
        private readonly string _connectionString;
        public DbSet<Package> Packages { get; set; }
        public DbSet<CurrentlyAuthorisedProduct> Products { get; set; }
        public DbSet<SuspendedProduct> SuspendedProducts { get; set; }
        public DbSet<ExpiredProduct> ExpiredProducts { get; set; }
        public DbSet<HomoeopathicProduct> HomoeopathicProducts { get; set; }
        public  DbSet<PackagedProduct> PackagedProducts{ get; set; }
        public DbSet<TargetSpecies> TargetSpecies { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }

        public VetMedDbContext(DbContextOptions options):base(options)
        {
            
        }

    }
}
