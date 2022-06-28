using HospR.Core.Entities;
using HospR.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospR.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public AppointmentController(IAppointmentService appointmentService, IPatientService patientService, IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        [HttpPost("AddAppointment")]
        public IActionResult AddAppointment(int patientId, int doctorId, DateTime start, DateTime end)
        {
            var patient = _patientService.Get(patientId);
            var doctor = _doctorService.Get(doctorId);
            if(patient == null || doctor == null)
            {
                return BadRequest();
            }
            //
            var currentAppointments = _appointmentService.GetAll();
            if(_patientService.PatientIsBusy(patient.Id, currentAppointments) 
                || _doctorService.DoctorIsBusy(doctor.Id, currentAppointments))
            {
                return BadRequest();
            }
            //
            var appointment = new Appointment(patientId, doctorId, start, end);
            _appointmentService.Add(appointment);
            return Ok();
        }

        [HttpGet("GetAppointment")]
        public IActionResult GetAppointment(int appointmentId)
        {
            var doctor = _appointmentService.Get(appointmentId);
            if (doctor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(doctor);
            }
        }

        [HttpGet("GetAllAppointments")]
        public IActionResult GetAllAppointments()
        {
            var appointments = _appointmentService.GetAll();
            if (appointments == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(appointments);
            }
        }

        [HttpPost("UpdateAppointment")]
        public IActionResult UpdateAppointment(int appointmentId, int patientId, int doctorId, DateTime start, DateTime end)
        {
            var fetchedAppointment = _appointmentService.Get(appointmentId);
            var fetchedDoctor = _doctorService.Get(doctorId);
            var fetchedPatient = _patientService.Get(patientId);
            if (fetchedAppointment == null)
            {
                return BadRequest();
            }
            if (fetchedDoctor == null)
            {
                return BadRequest();
            }
            if (fetchedPatient == null)
            {
                return BadRequest();
            }
            _appointmentService.Update(appointmentId, fetchedAppointment);
            return Ok();
        }

        [HttpPost("DeleteAppointment")]
        public IActionResult DeleteAppointment(int appointmentId)
        {
            _appointmentService.Delete(appointmentId);
            return Ok();
        }

        [HttpPost("GetAppointmentsOnInterval")]
        public IActionResult GetAppointmentsOnInterval(DateTime startDate, DateTime endDate)
        {
            var appointments = _appointmentService.GetAllAppointmentsOnInterval(startDate, endDate);
            return Ok(appointments);
        }
    }
}
