using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class ExpiredProductHistory :DbTableBase
    {
        public DateTime DateOfExpiration { get; set; }
        public string SpcLink { get; set; }
    }
}
