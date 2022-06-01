using HospR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Core.Interfaces.Services
{
    public interface IDoctorService
    {
        void Add(Doctor doctor);
        Doctor Get(int doctorId);
        List<Doctor> GetAll();
        void Delete(int doctorId);
        void Update(int doctorIdToChange, Doctor updatedDoctor);
        List<Doctor> GetAllAvaliableDoctors(DateTime date);
        List<Doctor> GetAllBuzyDoctors(DateTime date);
        void SetDiagnosis(string diagnosis, int appointmentId);
        bool DoctorIsBusy(int doctorId, List<Appointment> appointments);
    }
}
