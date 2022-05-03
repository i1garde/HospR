namespace HospR.Core.Interfaces;

public interface IUnitOfWork: IDisposable {
    IPatientRepository Patient { get; }
    IDoctorRepository Doctor { get; }
    IPatientCardRepository PatientCard { get; }
    IAppointmentRepository Appointment { get; }
    IAppointmentResultRepository AppointmentResult { get; }
    int Save();
}