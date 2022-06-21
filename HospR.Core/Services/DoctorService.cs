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

        public async Task Add(Doctor doctor)
        {
            await _unitOfWork.Doctors.Add(doctor);
            _unitOfWork.SaveChanges();
        }

        public async Task Delete(int doctorId)
        {
            await _unitOfWork.Doctors.Delete(doctorId);
            _unitOfWork.SaveChanges();
        }

        public async Task<Doctor> Get(int doctorId) => await _unitOfWork.Doctors.GetById(doctorId);

        public List<Doctor> GetAll() => _unitOfWork.Doctors.All().Result.ToList();

        public async Task Update(int doctorIdToChange, Doctor updatedDoctor)
        {
            var fetchedDoctor = await _unitOfWork.Doctors.GetById(doctorIdToChange);
            fetchedDoctor.Name = updatedDoctor.Name;
            fetchedDoctor.MedicalSpecialty = updatedDoctor.MedicalSpecialty;
            fetchedDoctor.ContactNumber = updatedDoctor.ContactNumber;
            await _unitOfWork.Doctors.Update(fetchedDoctor);
            _unitOfWork.SaveChanges();
        }

        public List<Doctor> GetAllBuzyDoctors(DateTime date)
        {
            var appointments = _unitOfWork.Appointments.All().Result.Where(app => app.StarTime <= date && app.EndTime >= date).ToList();
            var listOfDoctorIds = appointments.Select(x => x.DoctorId).ToList();
            var listOfDoctors = listOfDoctorIds.Select(x => _unitOfWork.Doctors.GetById(x).Result).ToList();
            return listOfDoctors;
        }

        public List<Doctor> GetAllAvaliableDoctors(DateTime date)
        {
            var allDoctors = GetAll();
            var listOfBusyDoctors = GetAllBuzyDoctors(date);
            var freeDoctors = allDoctors.Except(listOfBusyDoctors).ToList();
            return freeDoctors;
        }

        public async Task SetDiagnosis(string diagnosis, int appointmentId)
        {
            var appointment = await _unitOfWork.Appointments.GetById(appointmentId);
            var patient = await _unitOfWork.Patients.GetById(appointment.PatientId);
            var doctor = await _unitOfWork.Doctors.GetById(appointment.DoctorId);
            if(patient.AppointmentResults == null)
            {
                patient.AppointmentResults = new List<AppointmentResult>() { new AppointmentResult(diagnosis, doctor.Id, appointment.StarTime, patient.Id) };
            }
            else
            {
                patient.AppointmentResults.Add(new AppointmentResult(diagnosis, doctor.Id, appointment.StarTime, patient.Id));
            }
            await _unitOfWork.Patients.Update(patient);
            await _unitOfWork.Appointments.Delete(appointmentId);
            _unitOfWork.SaveChanges();
        }

        public bool DoctorIsBusy(int doctorId, List<Appointment> appointments)
        {
            return appointments.Any(x => x.DoctorId == doctorId);
        }
    }
}