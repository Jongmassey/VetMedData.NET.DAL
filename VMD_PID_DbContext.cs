using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class VMD_PID_DbContext : DbContext
    {
        public VMD_PID_DbContext()
        {
        }

        public VMD_PID_DbContext(DbContextOptions<VMD_PID_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiveSubstance> ActiveSubstance { get; set; }
        public virtual DbSet<ActiveSubstanceHistory> ActiveSubstanceHistory { get; set; }
        public virtual DbSet<CurrentlyAuthorisedProduct> CurrentlyAuthorisedProduct { get; set; }
        public virtual DbSet<CurrentlyAuthorisedProductDistributor> CurrentlyAuthorisedProductDistributor { get; set; }
        public virtual DbSet<CurrentlyAuthorisedProductDistributorHistory> CurrentlyAuthorisedProductDistributorHistory { get; set; }
        public virtual DbSet<CurrentlyAuthorisedProductHistory> CurrentlyAuthorisedProductHistory { get; set; }
        public virtual DbSet<Distributor> Distributor { get; set; }
        public virtual DbSet<DistributorHistory> DistributorHistory { get; set; }
        public virtual DbSet<ExpiredProduct> ExpiredProduct { get; set; }
        public virtual DbSet<ExpiredProductHistory> ExpiredProductHistory { get; set; }
        public virtual DbSet<HomoeopathicProduct> HomoeopathicProduct { get; set; }
        public virtual DbSet<HomoeopathicProductHistory> HomoeopathicProductHistory { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<PackageHistory> PackageHistory { get; set; }
        public virtual DbSet<PackageType> PackageType { get; set; }
        public virtual DbSet<PackageTypeHistory> PackageTypeHistory { get; set; }
        public virtual DbSet<PackagedProduct> PackagedProduct { get; set; }
        public virtual DbSet<PackagedProductHistory> PackagedProductHistory { get; set; }
        public virtual DbSet<PidVersion> PidVersion { get; set; }
        public virtual DbSet<ReferenceProduct> ReferenceProduct { get; set; }
        public virtual DbSet<ReferenceProductActiveSubstance> ReferenceProductActiveSubstance { get; set; }
        public virtual DbSet<ReferenceProductActiveSubstanceHistory> ReferenceProductActiveSubstanceHistory { get; set; }
        public virtual DbSet<ReferenceProductHistory> ReferenceProductHistory { get; set; }
        public virtual DbSet<ReferenceProductTargetSpecies> ReferenceProductTargetSpecies { get; set; }
        public virtual DbSet<ReferenceProductTargetSpeciesHistory> ReferenceProductTargetSpeciesHistory { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<SpeciesHistory> SpeciesHistory { get; set; }
        public virtual DbSet<SpeciesSynonym> SpeciesSynonym { get; set; }
        public virtual DbSet<SpeciesSynonymHistory> SpeciesSynonymHistory { get; set; }
        public virtual DbSet<SuspendedProduct> SuspendedProduct { get; set; }
        public virtual DbSet<SuspendedProductHistory> SuspendedProductHistory { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<UnitHistory> UnitHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var port = Environment.GetEnvironmentVariable("DB_PORT") ?? "1433";
            var server = Environment.GetEnvironmentVariable("DB_SERVER");
            var database = Environment.GetEnvironmentVariable("DB_NAME") ?? "VetMedData.NET";
            var username = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASS");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer($"server=tcp:{server}, {port};database={database};user id={username};password={password}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiveSubstance>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.ActiveSubstance)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__ActiveSub__PID_V__2EDAF651");
            });

            modelBuilder.Entity<ActiveSubstanceHistory>(entity =>
            {
                entity.ToTable("ActiveSubstance_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CurrentlyAuthorisedProduct>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ControlledDrug)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DistributionCategory)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PaarLink)
                    .IsRequired()
                    .HasColumnName("PAAR_Link");

                entity.Property(e => e.PharmaceuticalForm)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.SpcLink)
                    .IsRequired()
                    .HasColumnName("SPC_Link");

                entity.Property(e => e.TherapeuticGroup)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UkparLink)
                    .IsRequired()
                    .HasColumnName("UKPAR_Link");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.CurrentlyAuthorisedProduct)
                    .HasForeignKey<CurrentlyAuthorisedProduct>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CurrentlyAut__ID__6FE99F9F");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.CurrentlyAuthorisedProduct)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__Currently__PID_V__339FAB6E");
            });

            modelBuilder.Entity<CurrentlyAuthorisedProductDistributor>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CurrentlyAuthorisedProductNavigation)
                    .WithMany(p => p.CurrentlyAuthorisedProductDistributor)
                    .HasForeignKey(d => d.CurrentlyAuthorisedProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Currently__Curre__7B5B524B");

                entity.HasOne(d => d.DistributorNavigation)
                    .WithMany(p => p.CurrentlyAuthorisedProductDistributor)
                    .HasForeignKey(d => d.Distributor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Currently__Distr__7C4F7684");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.CurrentlyAuthorisedProductDistributor)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__Currently__PID_V__3493CFA7");
            });

            modelBuilder.Entity<CurrentlyAuthorisedProductDistributorHistory>(entity =>
            {
                entity.ToTable("CurrentlyAuthorisedProductDistributor_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CurrentlyAuthorisedProductHistory>(entity =>
            {
                entity.ToTable("CurrentlyAuthorisedProduct_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ControlledDrug)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DistributionCategory)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PaarLink)
                    .IsRequired()
                    .HasColumnName("PAAR_Link");

                entity.Property(e => e.PharmaceuticalForm)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.SpcLink)
                    .IsRequired()
                    .HasColumnName("SPC_Link");

                entity.Property(e => e.TherapeuticGroup)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UkparLink)
                    .IsRequired()
                    .HasColumnName("UKPAR_Link");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Distributor>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.Distributor)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__Distribut__PID_V__2FCF1A8A");
            });

            modelBuilder.Entity<DistributorHistory>(entity =>
            {
                entity.ToTable("Distributor_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ExpiredProduct>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfExpiration).HasColumnType("datetime");

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.SpcLink)
                    .IsRequired()
                    .HasColumnName("SPC_Link");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ExpiredProduct)
                    .HasForeignKey<ExpiredProduct>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExpiredProdu__ID__05D8E0BE");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.ExpiredProduct)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__ExpiredPr__PID_V__2739D489");
            });

            modelBuilder.Entity<ExpiredProductHistory>(entity =>
            {
                entity.ToTable("ExpiredProduct_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfExpiration).HasColumnType("datetime");

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.SpcLink)
                    .IsRequired()
                    .HasColumnName("SPC_Link");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<HomoeopathicProduct>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ControlledDrug)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfSuspension).HasColumnType("datetime");

                entity.Property(e => e.DistributionCategory)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PharmaceuticalForm)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.TherapeuticGroup)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.HomoeopathicProduct)
                    .HasForeignKey<HomoeopathicProduct>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Homoeopathic__ID__0C85DE4D");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.HomoeopathicProduct)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__Homoeopat__PID_V__282DF8C2");
            });

            modelBuilder.Entity<HomoeopathicProductHistory>(entity =>
            {
                entity.ToTable("HomoeopathicProduct_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ControlledDrug)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfSuspension).HasColumnType("datetime");

                entity.Property(e => e.DistributionCategory)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PharmaceuticalForm)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.TherapeuticGroup)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PackageTypeNavigation)
                    .WithMany(p => p.Package)
                    .HasForeignKey(d => d.PackageType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Package__Package__37A5467C");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.Package)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__Package__PID_Ver__2BFE89A6");
            });

            modelBuilder.Entity<PackageHistory>(entity =>
            {
                entity.ToTable("Package_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PackageType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.PackageType)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__PackageTy__PID_V__2B0A656D");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.PackageType)
                    .HasForeignKey(d => d.Unit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PackageTyp__Unit__300424B4");
            });

            modelBuilder.Entity<PackageTypeHistory>(entity =>
            {
                entity.ToTable("PackageType_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PackagedProduct>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Batch).HasMaxLength(255);

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Expiry).HasColumnType("datetime");

                entity.Property(e => e.Gtin)
                    .HasColumnName("GTIN")
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PackagedProductIdNavigation)
                    .HasForeignKey<PackagedProduct>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PackagedProd__ID__1332DBDC");

                entity.HasOne(d => d.PackageNavigation)
                    .WithMany(p => p.PackagedProduct)
                    .HasForeignKey(d => d.Package)
                    .HasConstraintName("FK__PackagedP__Packa__18EBB532");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.PackagedProduct)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__PackagedP__PID_V__29221CFB");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.PackagedProductProductNavigation)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK__PackagedP__Produ__17F790F9");
            });

            modelBuilder.Entity<PackagedProductHistory>(entity =>
            {
                entity.ToTable("PackagedProduct_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Batch).HasMaxLength(255);

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Expiry).HasColumnType("datetime");

                entity.Property(e => e.Gtin)
                    .HasColumnName("GTIN")
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PidVersion>(entity =>
            {
                entity.ToTable("PID_Version");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SourceUpdate).HasColumnType("datetime");

                entity.Property(e => e.SourceUrl)
                    .IsRequired()
                    .HasColumnName("SourceURL");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ReferenceProduct>(entity =>
            {
                entity.HasIndex(e => e.Vmno)
                    .HasName("UQ__Referenc__16C591A14D713B10")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AuthorisationRoute)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfIssue).HasColumnType("datetime");

                entity.Property(e => e.Maholder)
                    .IsRequired()
                    .HasColumnName("MAHolder");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Vmno)
                    .IsRequired()
                    .HasColumnName("VMNo")
                    .HasMaxLength(255);

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.ReferenceProduct)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__Reference__PID_V__30C33EC3");
            });

            modelBuilder.Entity<ReferenceProductActiveSubstance>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ActiveSubstanceNavigation)
                    .WithMany(p => p.ReferenceProductActiveSubstance)
                    .HasForeignKey(d => d.ActiveSubstance)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reference__Activ__6D0D32F4");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.ReferenceProductActiveSubstance)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__Reference__PID_V__32AB8735");

                entity.HasOne(d => d.ReferenceProductNavigation)
                    .WithMany(p => p.ReferenceProductActiveSubstance)
                    .HasForeignKey(d => d.ReferenceProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reference__Refer__6C190EBB");
            });

            modelBuilder.Entity<ReferenceProductActiveSubstanceHistory>(entity =>
            {
                entity.ToTable("ReferenceProductActiveSubstance_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ReferenceProductHistory>(entity =>
            {
                entity.ToTable("ReferenceProduct_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AuthorisationRoute)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfIssue).HasColumnType("datetime");

                entity.Property(e => e.Maholder)
                    .IsRequired()
                    .HasColumnName("MAHolder");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Vmno)
                    .IsRequired()
                    .HasColumnName("VMNo")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ReferenceProductTargetSpecies>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.ReferenceProductTargetSpecies)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__Reference__PID_V__31B762FC");

                entity.HasOne(d => d.ReferenceProductNavigation)
                    .WithMany(p => p.ReferenceProductTargetSpecies)
                    .HasForeignKey(d => d.ReferenceProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reference__Refer__6383C8BA");

                entity.HasOne(d => d.TargetSpeciesNavigation)
                    .WithMany(p => p.ReferenceProductTargetSpecies)
                    .HasForeignKey(d => d.TargetSpecies)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reference__Targe__6477ECF3");
            });

            modelBuilder.Entity<ReferenceProductTargetSpeciesHistory>(entity =>
            {
                entity.ToTable("ReferenceProductTargetSpecies_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__Species__PID_Ver__2CF2ADDF");
            });

            modelBuilder.Entity<SpeciesHistory>(entity =>
            {
                entity.ToTable("Species_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SpeciesSynonym>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CanonicalNameNavigation)
                    .WithMany(p => p.SpeciesSynonymCanonicalNameNavigation)
                    .HasForeignKey(d => d.CanonicalName)
                    .HasConstraintName("FK__SpeciesSy__Canon__45F365D3");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.SpeciesSynonym)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__SpeciesSy__PID_V__2DE6D218");

                entity.HasOne(d => d.SynonymNavigation)
                    .WithMany(p => p.SpeciesSynonymSynonymNavigation)
                    .HasForeignKey(d => d.Synonym)
                    .HasConstraintName("FK__SpeciesSy__Synon__46E78A0C");
            });

            modelBuilder.Entity<SpeciesSynonymHistory>(entity =>
            {
                entity.ToTable("SpeciesSynonym_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SuspendedProduct>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ControlledDrug)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfSuspension).HasColumnType("datetime");

                entity.Property(e => e.DistributionCategory)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PaarLink)
                    .IsRequired()
                    .HasColumnName("PAAR_Link");

                entity.Property(e => e.PharmaceuticalForm)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.SpcLink)
                    .IsRequired()
                    .HasColumnName("SPC_Link");

                entity.Property(e => e.TherapeuticGroup)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UkparLink)
                    .IsRequired()
                    .HasColumnName("UKPAR_Link");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.SuspendedProduct)
                    .HasForeignKey<SuspendedProduct>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SuspendedPro__ID__7F2BE32F");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.SuspendedProduct)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__Suspended__PID_V__3587F3E0");
            });

            modelBuilder.Entity<SuspendedProductHistory>(entity =>
            {
                entity.ToTable("SuspendedProduct_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ControlledDrug)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfSuspension).HasColumnType("datetime");

                entity.Property(e => e.DistributionCategory)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PaarLink)
                    .IsRequired()
                    .HasColumnName("PAAR_Link");

                entity.Property(e => e.PharmaceuticalForm)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.SpcLink)
                    .IsRequired()
                    .HasColumnName("SPC_Link");

                entity.Property(e => e.TherapeuticGroup)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UkparLink)
                    .IsRequired()
                    .HasColumnName("UKPAR_Link");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PidVersionNavigation)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.PidVersion)
                    .HasConstraintName("FK__Unit__PID_Versio__2A164134");
            });

            modelBuilder.Entity<UnitHistory>(entity =>
            {
                entity.ToTable("Unit_history");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PidVersion).HasColumnName("PID_Version");

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
