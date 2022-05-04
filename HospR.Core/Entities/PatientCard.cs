namespace HospR.Core.Entities;

public record PatientCard(
    int Id, 
    int PatientId, 
    Patient Patient,
    List<AppointmentResult> AppointmentResults
    );