using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospR.Core.Entities
{
    public class Patient : EntityBase<int>
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public PatientCard PatientCard { get; set; }

        private Patient()
        {
            
        }

        public Patient(string name, string contactNumber, string email, PatientCard patientCard)
        {
            Name = name;
            ContactNumber = contactNumber;
            Email = email;
            PatientCard = patientCard;
        }
    }
}
