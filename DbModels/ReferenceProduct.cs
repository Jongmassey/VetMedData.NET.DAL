using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class ReferenceProduct :DbTableBase
    {
        public ReferenceProduct()
        {
            PackagedProductProductNavigation = new HashSet<PackagedProduct>();
            ReferenceProductActiveSubstance = new HashSet<ReferenceProductActiveSubstance>();
            ReferenceProductTargetSpecies = new HashSet<ReferenceProductTargetSpecies>();
        }

        public string Name { get; set; }
        public string Maholder { get; set; }
        public string Vmno { get; set; }
        public string AuthorisationRoute { get; set; }
        public DateTime DateOfIssue { get; set; }

        public virtual CurrentlyAuthorisedProduct CurrentlyAuthorisedProduct { get; set; }
        public virtual ExpiredProduct ExpiredProduct { get; set; }
        public virtual HomoeopathicProduct HomoeopathicProduct { get; set; }
        public virtual PackagedProduct PackagedProductIdNavigation { get; set; }
        public virtual SuspendedProduct SuspendedProduct { get; set; }
        public virtual ICollection<PackagedProduct> PackagedProductProductNavigation { get; set; }
        public virtual ICollection<ReferenceProductActiveSubstance> ReferenceProductActiveSubstance { get; set; }
        public virtual ICollection<ReferenceProductTargetSpecies> ReferenceProductTargetSpecies { get; set; }
    }
}
