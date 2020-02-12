using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class Unit :DbTableBase
    {
        public Unit()
        {
            PackageType = new HashSet<PackageType>();
        }

        public string Name { get; set; }

        public virtual ICollection<PackageType> PackageType { get; set; }
    }
}
