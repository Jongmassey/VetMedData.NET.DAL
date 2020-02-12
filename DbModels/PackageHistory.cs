using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class PackageHistory :DbTableBase
    {
        public Guid PackageType { get; set; }
        public double PackageSize { get; set; }
    }
}
