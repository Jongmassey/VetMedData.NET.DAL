using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class PackageType :DbTableBase
    {
        public PackageType()
        {
            Package = new HashSet<Package>();
        }

        public string Name { get; set; }
        public Guid Unit { get; set; }

        public virtual Unit UnitNavigation { get; set; }
        public virtual ICollection<Package> Package { get; set; }
    }
}
