using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class ReferenceProductHistory :DbTableBase
    {
        public string Name { get; set; }
        public string Maholder { get; set; }
        public string Vmno { get; set; }
        public string AuthorisationRoute { get; set; }
        public DateTime DateOfIssue { get; set; }
    }
}
