using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class Species
    {
        public Species()
        {
            ReferenceProductTargetSpecies = new HashSet<ReferenceProductTargetSpecies>();
            SpeciesSynonymCanonicalNameNavigation = new HashSet<SpeciesSynonym>();
            SpeciesSynonymSynonymNavigation = new HashSet<SpeciesSynonym>();
        }

        public Guid Id { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ReferenceProductTargetSpecies> ReferenceProductTargetSpecies { get; set; }
        public virtual ICollection<SpeciesSynonym> SpeciesSynonymCanonicalNameNavigation { get; set; }
        public virtual ICollection<SpeciesSynonym> SpeciesSynonymSynonymNavigation { get; set; }
    }
}
