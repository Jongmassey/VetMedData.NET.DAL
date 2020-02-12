using System;
using System.Collections.Generic;
using System.Linq;

namespace VetMedData.NET.DAL.DbModels
{
    public abstract class DbTableBase
    {
        public Guid Id { get; set; }
        public DateTime Createdon { get; set; }
        public DateTime Updatedon { get; set; }
        public string Createdby { get; set; }
        public string Updatedby { get; set; }
        public Guid? PidVersion { get; set; }
        public virtual PidVersion PidVersionNavigation { get; set; }

        public override bool Equals(object? obj)
        {
            var ignoreProperties = new[]
                {"Id", "Createdon", "Updatedon", "Createdby", "Updatedby", "PidVersion", "PidVersionNavigation"};
            var propertyEquivalence = this.GetType().GetProperties().Where(p => !ignoreProperties.Contains(p.Name)).Select(propertyInfo => propertyInfo.GetValue(this).Equals(obj.GetType().GetProperty(propertyInfo.Name).GetValue(obj))).ToList();

            return propertyEquivalence.All(p => p);
        }
    }
}