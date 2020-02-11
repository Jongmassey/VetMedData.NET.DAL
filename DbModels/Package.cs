using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class Package
    {
        public Package()
        {
            PackagedProduct = new HashSet<PackagedProduct>();
        }

        public Guid Id { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public Guid PackageType { get; set; }
        public double PackageSize { get; set; }

        public virtual PackageType PackageTypeNavigation { get; set; }
        public virtual ICollection<PackagedProduct> PackagedProduct { get; set; }
    }
}
