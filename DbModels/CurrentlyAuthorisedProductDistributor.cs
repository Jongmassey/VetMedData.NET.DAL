using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class CurrentlyAuthorisedProductDistributor :DbTableBase
    {
        public Guid CurrentlyAuthorisedProduct { get; set; }
        public Guid Distributor { get; set; }

        public virtual CurrentlyAuthorisedProduct CurrentlyAuthorisedProductNavigation { get; set; }
        public virtual Distributor DistributorNavigation { get; set; }
    }
}
