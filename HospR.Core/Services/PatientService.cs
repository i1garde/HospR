using HospR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospR.Core.Interfaces.Services;
using HospR.Core.Interfaces.Infrastructure;

namespace HospR.Core.Services
{
    public class PatientService : IPatientService
    {
        private IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Patient patient)
        {
            _unitOfWork.Patients.Add(patient);
            _unitOfWork.SaveChanges();
        }

        public Patient Get(int patientId) => _unitOfWork.Patients.GetById(patientId);

        public void AddToDiseaseHistory(int patientId, AppointmentResult appointmentResult)
        {
            var patient = _unitOfWork.Patients.GetById(patientId);
            patient.AppointmentResults.Add(appointmentResult);
            _unitOfWork.Patients.Update(patient);
        }

        public List<Patient> GetAll() => _unitOfWork.Patients.All().ToList();

        public void Delete(int patientId)
        {
            _unitOfWork.Patients.Delete(patientId);
            _unitOfWork.SaveChanges();
        }

        public void Update(int patientIdToChange, Patient updatedPatient)
        {
            var fetchedPatient = _unitOfWork.Patients.GetById(patientIdToChange);
            fetchedPatient.Name = updatedPatient.Name;
            fetchedPatient.Email = updatedPatient.Email;
            fetchedPatient.ContactNumber = updatedPatient.ContactNumber;
            fetchedPatient.AppointmentResults = updatedPatient.AppointmentResults;
            _unitOfWork.Patients.Update(fetchedPatient);
            _unitOfWork.SaveChanges();
        }

        public List<AppointmentResult> GetAllAppointmentResultsByPatientId(int patientId)
        {
            return _unitOfWork.AppointmentResults.All().Where(x => x.PatientId == patientId).ToList();
        }

        public bool PatientIsBusy(int patientId, List<Appointment> appointments)
        {
            return appointments.Any(x => x.PatientId == patientId);
        }
    }
}
