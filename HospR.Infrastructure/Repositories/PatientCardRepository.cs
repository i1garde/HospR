using HospR.Core.Entities;
using HospR.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Infrastructure.Repositories
{
    public class PatientCardRepository : Repository<PatientCard, int>, IPatientCardRepository
    {
        public PatientCardRepository(HospRDbContext context) : base(context)
        {
        }
    }
}
