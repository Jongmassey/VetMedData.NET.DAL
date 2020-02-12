using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class HomoeopathicProductHistory :DbTableBase
    {
        
        public DateTime DateOfSuspension { get; set; }
        public string ControlledDrug { get; set; }
        public string DistributionCategory { get; set; }
        public string PharmaceuticalForm { get; set; }
        public string TherapeuticGroup { get; set; }
    }
}
