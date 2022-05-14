namespace HospR.Core.Interfaces;

public interface IUnitOfWork
{
    IPatientRepository Patients { get; }
    IDoctorRepository Doctors { get; }
    IPatientCardRepository PatientCards { get; }
    IAppointmentRepository Appointments { get; }
    IAppointmentResultRepository AppointmentResults { get; }

    Task CompleteAsync();
}
