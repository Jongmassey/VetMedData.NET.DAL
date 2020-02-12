using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class Package :DbTableBase
    {
        public Package()
        {
            PackagedProduct = new HashSet<PackagedProduct>();
        }

        public Guid PackageType { get; set; }
        public double PackageSize { get; set; }

        public virtual PackageType PackageTypeNavigation { get; set; }
        public virtual ICollection<PackagedProduct> PackagedProduct { get; set; }
    }
}
