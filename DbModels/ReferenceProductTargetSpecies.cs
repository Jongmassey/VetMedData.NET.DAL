using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class ReferenceProductTargetSpecies :DbTableBase
    {
        public Guid ReferenceProduct { get; set; }
        public Guid TargetSpecies { get; set; }

        public virtual ReferenceProduct ReferenceProductNavigation { get; set; }
        public virtual Species TargetSpeciesNavigation { get; set; }
    }
}
