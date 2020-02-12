﻿using System;
using System.Collections.Generic;

namespace VetMedData.NET.DAL.DbModels
{
    public partial class SpeciesSynonym :DbTableBase
    {
        public Guid? CanonicalName { get; set; }
        public Guid? Synonym { get; set; }

        public virtual Species CanonicalNameNavigation { get; set; }
        public virtual Species SynonymNavigation { get; set; }
    }
}
