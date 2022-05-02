namespace HospR.Core.Entities;

public record AppointmentResult(
    int Id, 
    string Diagnosis, 
    Doctor Doctor,
    DateOnly Date
    );