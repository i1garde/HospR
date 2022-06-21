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

        public async Task Add(Patient patient)
        {
            await _unitOfWork.Patients.Add(patient);
            _unitOfWork.SaveChanges();
        }

        public async Task<Patient> Get(int patientId) => await _unitOfWork.Patients.GetById(patientId);

        public async Task AddToDiseaseHistory(int patientId, AppointmentResult appointmentResult)
        {
            var patient = await _unitOfWork.Patients.GetById(patientId);
            patient.AppointmentResults.Add(appointmentResult);
            await _unitOfWork.Patients.Update(patient);
        }

        public async Task<IEnumerable<Patient>> GetAll() => await _unitOfWork.Patients.All();

        public async Task Delete(int patientId)
        {
            await _unitOfWork.Patients.Delete(patientId);
            _unitOfWork.SaveChanges();
        }

        public async Task Update(int patientIdToChange, Patient updatedPatient)
        {
            var fetchedPatient = await _unitOfWork.Patients.GetById(patientIdToChange);
            fetchedPatient.Name = updatedPatient.Name;
            fetchedPatient.Email = updatedPatient.Email;
            fetchedPatient.ContactNumber = updatedPatient.ContactNumber;
            fetchedPatient.AppointmentResults = updatedPatient.AppointmentResults;
            await _unitOfWork.Patients.Update(fetchedPatient);
            _unitOfWork.SaveChanges();
        }

        public List<AppointmentResult> GetAllAppointmentResultsByPatientId(int patientId)
        {
            return _unitOfWork.AppointmentResults.All().Result.Where(x => x.PatientId == patientId).ToList();
        }

        public bool PatientIsBusy(int patientId, List<Appointment> appointments)
        {
            return appointments.Any(x => x.PatientId == patientId);
        }
    }
}
