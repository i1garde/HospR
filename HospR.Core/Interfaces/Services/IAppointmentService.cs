using HospR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Core.Interfaces.Services
{
    public interface IAppointmentService
    {
        void Add(Appointment appointment);
        Appointment Get(int appointmentId);
        List<Appointment> GetAll();
        void Delete(int appointmentId);
        void Update(int appointmentIdToChange, Appointment updatedAppointment);
        List<Appointment> GetAllAppointmentsOnInterval(DateTime startDate, DateTime endDate);
    }
}
