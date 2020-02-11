using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class SpeciesSynonym
    {
        public Guid Id { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public Guid? CanonicalName { get; set; }
        public Guid? Synonym { get; set; }

        public virtual Species CanonicalNameNavigation { get; set; }
        public virtual Species SynonymNavigation { get; set; }
    }
}
