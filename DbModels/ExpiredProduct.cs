﻿using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class ExpiredProduct :DbTableBase
    {
        public DateTime DateOfExpiration { get; set; }
        public string SpcLink { get; set; }

        public virtual ReferenceProduct IdNavigation { get; set; }
    }
}
