using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class PackagedProductHistory :DbTableBase
    {
        public Guid? Product { get; set; }
        public Guid? Package { get; set; }
        public DateTime? Expiry { get; set; }
        public string Batch { get; set; }
        public string Gtin { get; set; }
    }
}
