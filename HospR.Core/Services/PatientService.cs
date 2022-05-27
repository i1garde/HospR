using HospR.Core.Interfaces;
using HospR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
