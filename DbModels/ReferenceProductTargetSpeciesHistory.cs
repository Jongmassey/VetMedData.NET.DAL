using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class ReferenceProductTargetSpeciesHistory :DbTableBase
    {
        public Guid ReferenceProduct { get; set; }
        public Guid TargetSpecies { get; set; }
    }
}
