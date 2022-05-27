using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Core.Entities
{
    public class Appointment : EntityBase<int>
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
