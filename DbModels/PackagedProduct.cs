using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class PackagedProduct
    {
        public Guid Id { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public Guid? Product { get; set; }
        public Guid? Package { get; set; }
        public DateTime? Expiry { get; set; }
        public string Batch { get; set; }
        public string Gtin { get; set; }

        public virtual ReferenceProduct IdNavigation { get; set; }
        public virtual Package PackageNavigation { get; set; }
        public virtual ReferenceProduct ProductNavigation { get; set; }
    }
}
