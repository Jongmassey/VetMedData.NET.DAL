using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class Distributor
    {
        public Distributor()
        {
            CurrentlyAuthorisedProductDistributor = new HashSet<CurrentlyAuthorisedProductDistributor>();
        }

        public Guid Id { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CurrentlyAuthorisedProductDistributor> CurrentlyAuthorisedProductDistributor { get; set; }
    }
}
