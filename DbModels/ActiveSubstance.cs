using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class ActiveSubstance : DbTableBase
    {
        public ActiveSubstance()
        {
            ReferenceProductActiveSubstance = new HashSet<ReferenceProductActiveSubstance>();
        }

        public string Name { get; set; }
        public virtual ICollection<ReferenceProductActiveSubstance> ReferenceProductActiveSubstance { get; set; }
    }
}
