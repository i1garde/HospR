using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospR.Core.Entities
{
    public record Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; init; }
        public string Name { get; init; }
        public string ContactNumber { get; init; }
        public string Email { get; init; }
        public PatientCard PatientCard { get; set; }
        private Patient() { }
        public Patient(string name, string contactNum, string email){
            Name = name;
            ContactNumber = contactNum;
            Email = email;
        }
    }
}
