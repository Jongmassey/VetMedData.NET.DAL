using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class PackageTypeHistory :DbTableBase
    {
        public string Name { get; set; }
        public Guid Unit { get; set; }
    }
}
