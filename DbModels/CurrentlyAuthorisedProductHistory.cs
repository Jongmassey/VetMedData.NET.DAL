using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class CurrentlyAuthorisedProductHistory :DbTableBase
    {
        public string ControlledDrug { get; set; }
        public string DistributionCategory { get; set; }
        public string PharmaceuticalForm { get; set; }
        public string TherapeuticGroup { get; set; }
        public string SpcLink { get; set; }
        public string UkparLink { get; set; }
        public string PaarLink { get; set; }
    }
}
