using System.ComponentModel.DataAnnotations.Schema;

namespace HospR.Core.Entities;

public class PatientCard : EntityBase<int>
{
    public Patient Patient { get; set; }
    public int PatientId { get; set; }
    public List<AppointmentResult> AppointmentResults { get; set; }

    private PatientCard()
    {

    }

    public PatientCard(Patient patient, int patientId, List<AppointmentResult> appointmentResults)
    {
        Patient = patient;
        PatientId = patientId;
        AppointmentResults = appointmentResults;
    }
}