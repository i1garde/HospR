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
        Task Add(Patient patient);
        Task<Patient> Get(int patientId);
        Task<IEnumerable<Patient>> GetAll();
        Task Delete(int patientId);
        Task Update(int patientIdToChange, Patient updatedPatient);
        Task AddToDiseaseHistory(int patientId, AppointmentResult appointmentResult);
        List<AppointmentResult> GetAllAppointmentResultsByPatientId(int patientId);
        bool PatientIsBusy(int patientId, List<Appointment> appointments);
    }
}
