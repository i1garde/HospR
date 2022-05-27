using HospR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospR.Core.Interfaces
{
    public interface IPatientService
    {
        void Add(Patient patient);
    }
}
