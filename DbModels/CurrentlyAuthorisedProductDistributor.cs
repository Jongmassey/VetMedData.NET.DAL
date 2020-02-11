using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class CurrentlyAuthorisedProductDistributor
    {
        public Guid Id { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public Guid CurrentlyAuthorisedProduct { get; set; }
        public Guid Distributor { get; set; }

        public virtual CurrentlyAuthorisedProduct CurrentlyAuthorisedProductNavigation { get; set; }
        public virtual Distributor DistributorNavigation { get; set; }
    }
}
