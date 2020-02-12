﻿using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class SuspendedProduct :DbTableBase
    {
        public DateTime DateOfSuspension { get; set; }
        public string ControlledDrug { get; set; }
        public string DistributionCategory { get; set; }
        public string PharmaceuticalForm { get; set; }
        public string TherapeuticGroup { get; set; }
        public string SpcLink { get; set; }
        public string UkparLink { get; set; }
        public string PaarLink { get; set; }

        public virtual ReferenceProduct IdNavigation { get; set; }
    }
}
