using System;
using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<ActiveSubstance> ActiveSubstances { get; set; }
        public virtual DbSet<CurrentlyAuthorisedProduct> CurrentlyAuthorisedProducts { get; set; }
        public virtual DbSet<CurrentlyAuthorisedProductDistributor> CurrentlyAuthorisedProductDistributors { get; set; }
        public virtual DbSet<Distributor> Distributors { get; set; }
        public virtual DbSet<ExpiredProduct> ExpiredProducts { get; set; }
        public virtual DbSet<HomoeopathicProduct> HomoeopathicProducts { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackageType> PackageTypes { get; set; }
        public virtual DbSet<PackagedProduct> PackagedProducts { get; set; }
        public virtual DbSet<ReferenceProduct> ReferenceProducts { get; set; }
        public virtual DbSet<ReferenceProductActiveSubstance> ReferenceProductActiveSubstances { get; set; }
        public virtual DbSet<ReferenceProductTargetSpecies> ReferenceProductTargetSpecies { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<SpeciesSynonym> SpeciesSynonyms { get; set; }
        public virtual DbSet<SuspendedProduct> SuspendedProducts { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

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

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.PackageType)
                    .HasForeignKey(d => d.Unit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PackageTyp__Unit__300424B4");
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

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.PackagedProductProductNavigation)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK__PackagedP__Produ__17F790F9");
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

                entity.HasOne(d => d.ReferenceProductNavigation)
                    .WithMany(p => p.ReferenceProductActiveSubstance)
                    .HasForeignKey(d => d.ReferenceProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reference__Refer__6C190EBB");
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

                entity.Property(e => e.Updatedby)
                    .IsRequired()
                    .HasColumnName("updatedby")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Updatedon)
                    .HasColumnName("updatedon")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

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

                entity.HasOne(d => d.SynonymNavigation)
                    .WithMany(p => p.SpeciesSynonymSynonymNavigation)
                    .HasForeignKey(d => d.Synonym)
                    .HasConstraintName("FK__SpeciesSy__Synon__46E78A0C");
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
