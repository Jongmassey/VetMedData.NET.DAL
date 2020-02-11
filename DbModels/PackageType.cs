using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class PackageType
    {
        public PackageType()
        {
            Package = new HashSet<Package>();
        }

        public Guid Id { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public string Name { get; set; }
        public Guid Unit { get; set; }

        public virtual Unit UnitNavigation { get; set; }
        public virtual ICollection<Package> Package { get; set; }
    }
}
