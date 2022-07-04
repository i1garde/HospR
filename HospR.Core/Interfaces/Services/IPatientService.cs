using HospR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Core.Interfaces.Services
{
    public interface IPatientService
    {
        void Add(Patient patient);
        Patient Get(int patientId);
        List<Patient> GetAll();
        void Delete(int patientId);
        void Update(int patientIdToChange, Patient updatedPatient);
        void AddToDiseaseHistory(int patientId, AppointmentResult appointmentResult);
        List<AppointmentResult> GetAllAppointmentResultsByPatientId(int patientId);
        bool PatientIsBusy(int patientId, List<Appointment> appointments);
        public Task<IEnumerable<Patient>> GetAllPatientsWithNameLongerThanFourAsync();
    }
}
