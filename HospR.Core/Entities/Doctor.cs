using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospR.Core.Enumerations;

namespace HospR.Core.Entities
{
    public record Doctor(
        int Id, 
        string Name,
        MedicalSpecialty MedicalSpecialty,
        string ContactNumber
        );
}
