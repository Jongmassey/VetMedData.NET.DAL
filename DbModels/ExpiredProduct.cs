using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class ExpiredProduct
    {
        public Guid Id { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public string SpcLink { get; set; }

        public virtual ReferenceProduct IdNavigation { get; set; }
    }
}
