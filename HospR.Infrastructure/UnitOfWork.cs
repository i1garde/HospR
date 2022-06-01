using HospR.Core.Interfaces.Infrastructure;
using HospR.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospRDbContext _context;
        private bool isDisposed;

        public IPatientRepository Patients { get; private set; }
        public IDoctorRepository Doctors { get; private set; }
        public IAppointmentRepository Appointments { get; private set; }
        public IAppointmentResultRepository AppointmentResults { get; private set; }

        public UnitOfWork(HospRDbContext context)
        {
            _context = context;
            Patients = new PatientRepository(context);
            Doctors = new DoctorRepository(context);
            Appointments = new AppointmentRepository(context);
            AppointmentResults = new AppointmentResultRepository(context);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
