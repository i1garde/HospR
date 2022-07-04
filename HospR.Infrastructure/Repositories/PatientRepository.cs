using HospR.Core.Entities;
using HospR.Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HospR.Infrastructure.Repositories
{
    public class PatientRepository : Repository<Patient, int>, IPatientRepository
    {
        public PatientRepository(HospRDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Patient>> AllPatientsAsync()
        {
            return await _hospRDbContext.Patients.ToListAsync();
        }
    }
}
