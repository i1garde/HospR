using HospR.Core.Entities;

namespace HospR.Core.Interfaces.Infrastructure;

public interface IPatientRepository : IRepository<Patient, int>
{
    public Task<IEnumerable<Patient>> AllPatientsAsync();
}
