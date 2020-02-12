using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class Distributor :DbTableBase
    {
        public Distributor()
        {
            CurrentlyAuthorisedProductDistributor = new HashSet<CurrentlyAuthorisedProductDistributor>();
        }

        public string Name { get; set; }

        public virtual ICollection<CurrentlyAuthorisedProductDistributor> CurrentlyAuthorisedProductDistributor { get; set; }
    }
}
