using HospR.Core.Entities;
using HospR.Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Infrastructure.Repositories
{
    public class DoctorRepository : Repository<Doctor, int>, IDoctorRepository
    {
        public DoctorRepository(HospRDbContext context) : base(context)
        {
        }
    }
}
