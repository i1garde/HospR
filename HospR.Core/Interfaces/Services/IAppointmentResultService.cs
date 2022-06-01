using HospR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Core.Interfaces.Services
{
    public interface IAppointmentResultService
    {
        void Add(AppointmentResult appointmentResult);
        AppointmentResult Get(int appointmentResultId);
        List<AppointmentResult> GetAll();
        void Delete(int appointmentResultId);
        void Update(int appointmentResultIdToChange, AppointmentResult updatedAppointmentResult);
    }
}
