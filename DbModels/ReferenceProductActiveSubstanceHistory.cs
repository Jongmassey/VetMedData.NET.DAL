using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class ReferenceProductActiveSubstanceHistory :DbTableBase
    {
        public Guid ReferenceProduct { get; set; }
        public Guid ActiveSubstance { get; set; }
    }
}
