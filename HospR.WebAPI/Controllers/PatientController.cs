using HospR.Core.Entities;
using HospR.Core.Interfaces.Services;
using HospR.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HospR.Core.Interfaces.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("GetPatient")]
        public async Task<IActionResult> GetPatient(int patientId)
        {
            var patient = await _patientService.Get(patientId);
            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(patient);
            }
        }

        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAll();
            if (patients == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(patients);
            }
        }

        [HttpPost("AddPatient")]
        public async Task<IActionResult> AddPatient(string name, string number, string email)
        {
            var patient = new Patient(name, number, email, new List<AppointmentResult>());
            await _patientService.Add(patient);
            return Ok();
        }

        [HttpPost("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(int patientId, string name, string number, string email)
        {
            var fetchedPatient = await _patientService.Get(patientId);
            if(fetchedPatient == null)
            {
                return BadRequest();
            }
            if(name != null)
            { 
                fetchedPatient.Name = name;
            }
            if (number != null)
            {
                fetchedPatient.ContactNumber = number;
            }
            if (email != null)
            {
                fetchedPatient.Email = email;
            }
            await _patientService.Update(patientId, fetchedPatient);
            return Ok();
        }

        [HttpPost("DeletePatient")]
        public async Task<IActionResult> DeletePatient(int patientId)
        {
            await _patientService.Delete(patientId);
            return Ok();
        }

        [HttpGet("GetDiseaseHistory")]
        public IActionResult GetDiseaseHistory(int patientId)
        {
            var diseaseHistory = _patientService.GetAllAppointmentResultsByPatientId(patientId);
            return Ok(diseaseHistory);
        }
    }
}
