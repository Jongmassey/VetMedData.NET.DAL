using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class CurrentlyAuthorisedProduct
    {
        public CurrentlyAuthorisedProduct()
        {
            CurrentlyAuthorisedProductDistributor = new HashSet<CurrentlyAuthorisedProductDistributor>();
        }

        public Guid Id { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public string ControlledDrug { get; set; }
        public string DistributionCategory { get; set; }
        public string PharmaceuticalForm { get; set; }
        public string TherapeuticGroup { get; set; }
        public string SpcLink { get; set; }
        public string UkparLink { get; set; }
        public string PaarLink { get; set; }

        public virtual ReferenceProduct IdNavigation { get; set; }
        public virtual ICollection<CurrentlyAuthorisedProductDistributor> CurrentlyAuthorisedProductDistributor { get; set; }
    }
}
