using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospR.Core.Enumerations;

namespace HospR.Core.Entities
{
    public class Doctor : EntityBase<int>
    {
        public string Name { get; set; }
        public MedicalSpecialty MedicalSpecialty { get; set; }
        public string ContactNumber { get; set; }
    }
}
