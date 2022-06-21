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
        Task Add(Appointment appointment);
        Task<Appointment> Get(int appointmentId);
        List<Appointment> GetAll();
        Task Delete(int appointmentId);
        Task Update(int appointmentIdToChange, Appointment updatedAppointment);
        List<Appointment> GetAllAppointmentsOnInterval(DateTime startDate, DateTime endDate);
    }
}
