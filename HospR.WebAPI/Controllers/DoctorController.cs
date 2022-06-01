using HospR.Core.Entities;
using HospR.Core.Enumerations;
using HospR.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost("AddDoctor")]
        public IActionResult AddDoctor(string name, string number, MedicalSpecialty medSpec)
        {
            var doctor = new Doctor(name, number, medSpec);
            _doctorService.Add(doctor);
            return Ok();
        }

        [HttpGet("GetDoctor")]
        public IActionResult GetDoctor(int doctorId)
        {
            var doctor = _doctorService.Get(doctorId);
            if (doctor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(doctor);
            }
        }

        [HttpGet("GetAllDoctors")]
        public IActionResult GetAllDoctors()
        {
            var patients = _doctorService.GetAll();
            if (patients == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(patients);
            }
        }

        [HttpPost("UpdateDoctor")]
        public IActionResult UpdateDoctor(int doctorId, string name, string number, MedicalSpecialty medSpec)
        {
            var fetchedDoctor = _doctorService.Get(doctorId);
            if (fetchedDoctor == null)
            {
                return BadRequest();
            }
            if (name != null)
            {
                fetchedDoctor.Name = name;
            }
            if (number != null)
            {
                fetchedDoctor.ContactNumber = number;
            }
            if (medSpec != null)
            {
                fetchedDoctor.MedicalSpecialty = medSpec;
            }
            _doctorService.Update(doctorId, fetchedDoctor);
            return Ok();
        }

        [HttpPost("DeleteDoctor")]
        public IActionResult DeleteDoctor(int doctorId)
        {
            _doctorService.Delete(doctorId);
            return Ok();
        }

        [HttpGet("GetAvaliableDoctors")]
        public IActionResult GetAvaliableDoctors(DateTime date)
        {
            var doctors = _doctorService.GetAllAvaliableDoctors(date);
            return Ok(doctors);
        }

        [HttpPost("EstablishDiagnosis")]
        public IActionResult EstablishDiagnosis(string diagnosis, int appointmentId)
        {
            _doctorService.SetDiagnosis(diagnosis, appointmentId);
            return Ok();
        }
    }
}
