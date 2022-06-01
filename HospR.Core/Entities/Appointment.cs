using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Core.Entities
{
    public class Appointment : EntityBase<int>
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }

        private Appointment()
        {

        }

        public Appointment(int patientId, int doctorId, DateTime start, DateTime end)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            StarTime = start;
            EndTime = end;
        }
    }
}
