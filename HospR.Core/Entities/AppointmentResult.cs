namespace HospR.Core.Entities;

public class AppointmentResult : EntityBase<int>
{
    public string Diagnosis { get; set; }
    public int DoctorId { get; set; }
    public DateTime Date { get; set; }
    public int PatientId { get; set; }

    private AppointmentResult()
    {

    }

    public AppointmentResult(string diagnosis, int doctorId, DateTime date, int patientId)
    {
        Diagnosis = diagnosis;
        DoctorId = doctorId;
        Date = date;
        PatientId = patientId;
    }
}