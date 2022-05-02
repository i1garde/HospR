using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Core.Entities
{
    public record Appointment(
        int Id, 
        Patient Patient,
        Doctor Doctor,
        DateTime StarTime,
        DateTime EndTime
        );
}
