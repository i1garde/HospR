namespace HospR.Core.Interfaces.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    IPatientRepository Patients { get; }
    IDoctorRepository Doctors { get; }
    IAppointmentRepository Appointments { get; }
    IAppointmentResultRepository AppointmentResults { get; }

    void SaveChanges();
}
