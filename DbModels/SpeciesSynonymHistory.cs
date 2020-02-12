using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class SpeciesSynonymHistory :DbTableBase
    {
        public Guid? CanonicalName { get; set; }
        public Guid? Synonym { get; set; }
    }
}
