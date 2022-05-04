using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospR.Core.Entities;

namespace HospR.Core.Services
{
    public static class Extensions
    {
        public static AppointmentResult ToAppointmentResult(this Appointment appointment, string diagnosis)
            => new AppointmentResult(appointment.Id, "Anemia", appointment.Doctor ,new DateTime(2022, 6, 13).Date);
    }
}
