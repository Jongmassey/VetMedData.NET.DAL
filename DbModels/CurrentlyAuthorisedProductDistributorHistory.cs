using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class CurrentlyAuthorisedProductDistributorHistory :DbTableBase
    {
        public Guid CurrentlyAuthorisedProduct { get; set; }
        public Guid Distributor { get; set; }
    }
}
