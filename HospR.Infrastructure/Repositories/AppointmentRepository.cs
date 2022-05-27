using HospR.Core.Entities;
using HospR.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Infrastructure.Repositories
{
    public class AppointmentRepository : Repository<Appointment, int>, IAppointmentRepository
    {
        public AppointmentRepository(HospRDbContext context) : base(context)
        {
        }
    }
}
