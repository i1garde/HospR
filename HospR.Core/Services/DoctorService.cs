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
    public class DoctorService : IDoctorService
    {
        private IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Doctor doctor)
        {
            _unitOfWork.Doctors.Add(doctor);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int doctorId)
        {
            _unitOfWork.Doctors.Delete(doctorId);
            _unitOfWork.SaveChanges();
        }

        public Doctor Get(int doctorId) => _unitOfWork.Doctors.GetById(doctorId);

        public List<Doctor> GetAll() => _unitOfWork.Doctors.All().ToList();

        public void Update(int doctorIdToChange, Doctor updatedDoctor)
        {
            var fetchedDoctor = _unitOfWork.Doctors.GetById(doctorIdToChange);
            fetchedDoctor.Name = updatedDoctor.Name;
            fetchedDoctor.MedicalSpecialty = updatedDoctor.MedicalSpecialty;
            fetchedDoctor.ContactNumber = updatedDoctor.ContactNumber;
            _unitOfWork.Doctors.Update(fetchedDoctor);
            _unitOfWork.SaveChanges();
        }

        public List<Doctor> GetAllBuzyDoctors(DateTime date)
        {
            var appointments = _unitOfWork.Appointments.All().Where(app => app.StarTime <= date && app.EndTime >= date).ToList();
            var listOfDoctorIds = appointments.Select(x => x.DoctorId).ToList();
            var listOfDoctors = listOfDoctorIds.Select(x => _unitOfWork.Doctors.GetById(x)).ToList();
            return listOfDoctors;
        }

        public List<Doctor> GetAllAvaliableDoctors(DateTime date)
        {
            var allDoctors = GetAll();
            var listOfBusyDoctors = GetAllBuzyDoctors(date);
            var freeDoctors = allDoctors.Except(listOfBusyDoctors).ToList();
            return freeDoctors;
        }

        public void SetDiagnosis(string diagnosis, int appointmentId)
        {
            var appointment = _unitOfWork.Appointments.GetById(appointmentId);
            var patient = _unitOfWork.Patients.GetById(appointment.PatientId);
            var doctor = _unitOfWork.Doctors.GetById(appointment.DoctorId);
            if(patient.AppointmentResults == null)
            {
                patient.AppointmentResults = new List<AppointmentResult>() { new AppointmentResult(diagnosis, doctor.Id, appointment.StarTime, patient.Id) };
            }
            else
            {
                patient.AppointmentResults.Add(new AppointmentResult(diagnosis, doctor.Id, appointment.StarTime, patient.Id));
            }
            _unitOfWork.Patients.Update(patient);
            _unitOfWork.Appointments.Delete(appointmentId);
            _unitOfWork.SaveChanges();
        }

        public bool DoctorIsBusy(int doctorId, List<Appointment> appointments)
        {
            return appointments.Any(x => x.DoctorId == doctorId);
        }
    }
}