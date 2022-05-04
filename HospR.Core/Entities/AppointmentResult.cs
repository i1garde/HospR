namespace HospR.Core.Entities;

public record AppointmentResult(
    int Id,
    string Diagnosis,
    Doctor Doctor,
    DateTime Date,
    int PatientCardId,
    PatientCard PatientCard
    );
