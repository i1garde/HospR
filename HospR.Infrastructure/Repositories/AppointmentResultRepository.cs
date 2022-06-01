using HospR.Core.Entities;
using HospR.Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Infrastructure.Repositories
{
    public class AppointmentResultRepository : Repository<AppointmentResult, int>, IAppointmentResultRepository
    {
        public AppointmentResultRepository(HospRDbContext context) : base(context)
        {
        }
    }
}
