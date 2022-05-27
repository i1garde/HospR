namespace HospR.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IPatientRepository Patients { get; }
    IDoctorRepository Doctors { get; }
    IPatientCardRepository PatientCards { get; }
    IAppointmentRepository Appointments { get; }
    IAppointmentResultRepository AppointmentResults { get; }

    void SaveChanges();
}
