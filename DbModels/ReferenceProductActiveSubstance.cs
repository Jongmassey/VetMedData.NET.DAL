using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class ReferenceProductActiveSubstance
    {
        public Guid Id { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public Guid ReferenceProduct { get; set; }
        public Guid ActiveSubstance { get; set; }

        public virtual ActiveSubstance ActiveSubstanceNavigation { get; set; }
        public virtual ReferenceProduct ReferenceProductNavigation { get; set; }
    }
}
