using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class PidVersion 
    {
        public PidVersion()
        {
            ActiveSubstance = new HashSet<ActiveSubstance>();
            CurrentlyAuthorisedProduct = new HashSet<CurrentlyAuthorisedProduct>();
            CurrentlyAuthorisedProductDistributor = new HashSet<CurrentlyAuthorisedProductDistributor>();
            Distributor = new HashSet<Distributor>();
            ExpiredProduct = new HashSet<ExpiredProduct>();
            HomoeopathicProduct = new HashSet<HomoeopathicProduct>();
            Package = new HashSet<Package>();
            PackageType = new HashSet<PackageType>();
            PackagedProduct = new HashSet<PackagedProduct>();
            ReferenceProduct = new HashSet<ReferenceProduct>();
            ReferenceProductActiveSubstance = new HashSet<ReferenceProductActiveSubstance>();
            ReferenceProductTargetSpecies = new HashSet<ReferenceProductTargetSpecies>();
            Species = new HashSet<Species>();
            SpeciesSynonym = new HashSet<SpeciesSynonym>();
            SuspendedProduct = new HashSet<SuspendedProduct>();
            Unit = new HashSet<Unit>();
        }

        public Guid Id { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public DateTime SourceUpdate { get; set; }
        public string SourceUrl { get; set; }

        public virtual ICollection<ActiveSubstance> ActiveSubstance { get; set; }
        public virtual ICollection<CurrentlyAuthorisedProduct> CurrentlyAuthorisedProduct { get; set; }
        public virtual ICollection<CurrentlyAuthorisedProductDistributor> CurrentlyAuthorisedProductDistributor { get; set; }
        public virtual ICollection<Distributor> Distributor { get; set; }
        public virtual ICollection<ExpiredProduct> ExpiredProduct { get; set; }
        public virtual ICollection<HomoeopathicProduct> HomoeopathicProduct { get; set; }
        public virtual ICollection<Package> Package { get; set; }
        public virtual ICollection<PackageType> PackageType { get; set; }
        public virtual ICollection<PackagedProduct> PackagedProduct { get; set; }
        public virtual ICollection<ReferenceProduct> ReferenceProduct { get; set; }
        public virtual ICollection<ReferenceProductActiveSubstance> ReferenceProductActiveSubstance { get; set; }
        public virtual ICollection<ReferenceProductTargetSpecies> ReferenceProductTargetSpecies { get; set; }
        public virtual ICollection<Species> Species { get; set; }
        public virtual ICollection<SpeciesSynonym> SpeciesSynonym { get; set; }
        public virtual ICollection<SuspendedProduct> SuspendedProduct { get; set; }
        public virtual ICollection<Unit> Unit { get; set; }
    }
}
