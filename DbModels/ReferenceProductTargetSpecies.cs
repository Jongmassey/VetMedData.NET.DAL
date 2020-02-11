using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class ReferenceProductTargetSpecies
    {
        public Guid Id { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public Guid ReferenceProduct { get; set; }
        public Guid TargetSpecies { get; set; }

        public virtual ReferenceProduct ReferenceProductNavigation { get; set; }
        public virtual Species TargetSpeciesNavigation { get; set; }
    }
}
