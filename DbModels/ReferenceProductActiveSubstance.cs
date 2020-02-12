using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class ReferenceProductActiveSubstance :DbTableBase
    {
        public Guid ReferenceProduct { get; set; }
        public Guid ActiveSubstance { get; set; }

        public virtual ActiveSubstance ActiveSubstanceNavigation { get; set; }
        public virtual ReferenceProduct ReferenceProductNavigation { get; set; }
    }
}
