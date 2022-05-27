namespace HospR.Core.Entities;

public class AppointmentResult : EntityBase<int>
{
    public string Diagnosis { get; set; }
    public Doctor Doctor { get; set; }
    public DateTime Date { get; set; }
    public int PatientCardId { get; set; }
    public PatientCard PatientCard { get; set; }
}