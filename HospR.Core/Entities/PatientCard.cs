using System.ComponentModel.DataAnnotations.Schema;

namespace HospR.Core.Entities;

public record PatientCard
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PatientCardId { get; init; }
    public Patient Patient { get; init; }
    public int PatientId { get; init; }
    public List<AppointmentResult> AppointmentResults { get; init; }
    private PatientCard() { }
}