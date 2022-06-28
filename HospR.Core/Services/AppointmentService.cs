using HospR.Core.Entities;
using HospR.Core.Interfaces.Infrastructure;
using HospR.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Core.Services
{
    public class AppointmentService : IAppointmentService
    {
        private IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Appointment appointment)
        {
            _unitOfWork.Appointments.Add(appointment);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int appointmentId)
        {
            _unitOfWork.Appointments.Delete(appointmentId);
            _unitOfWork.SaveChanges();
        }

        public Appointment Get(int appointmentId) => _unitOfWork.Appointments.GetById(appointmentId);

        public List<Appointment> GetAll() => _unitOfWork.Appointments.All().ToList();

        public void Update(int appointmentIdToChange, Appointment updatedAppointment)
        {
            var fetchedAppointment = _unitOfWork.Appointments.GetById(appointmentIdToChange);
            fetchedAppointment.PatientId = updatedAppointment.PatientId;
            fetchedAppointment.DoctorId = updatedAppointment.DoctorId;
            fetchedAppointment.StarTime = updatedAppointment.StarTime;
            fetchedAppointment.EndTime = updatedAppointment.EndTime;
            _unitOfWork.Appointments.Update(fetchedAppointment);
            _unitOfWork.SaveChanges();
        }

        public List<Appointment> GetAllAppointmentsOnInterval(DateTime startDate, DateTime endDate)
        {
            var appointments = _unitOfWork.Appointments.All().Where(x => x.StarTime >= startDate && x.EndTime <= endDate).ToList();
            return appointments;
        }
    }
}
