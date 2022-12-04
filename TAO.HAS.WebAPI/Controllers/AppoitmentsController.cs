using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Entities.Concrete;

namespace TAO.HAS.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AppoitmentsController : ControllerBase
  {
    IAppointmentService _appointmentService;
    public AppoitmentsController(IAppointmentService appointmentService)
    {
      _appointmentService = appointmentService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
      var result = _appointmentService.GetAll();
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("getbypatientid")]
    public IActionResult GetByPatientId(int patientId)
    {
      var result = _appointmentService.GetByPatientId(patientId);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("getbydoctorid")]
    public IActionResult GetByDoctorId(int doctorId)
    {
      var result = _appointmentService.GetByDoctorId(doctorId);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpPost("add")]
    public IActionResult Add(Appointment appointment)
    {
      var result = _appointmentService.Add(appointment);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpPost("update")]
    public IActionResult Update(Appointment appointment)
    {
      var result = _appointmentService.Update(appointment);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpPost("delete")]
    public IActionResult Delete(Appointment appointment)
    {
      var result = _appointmentService.Delete(appointment);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
     
    }

    [HttpGet("getappointmentdetails")]
    public IActionResult GetAppointmentDetails()
    {
      var result = _appointmentService.GetAppointmentDetails();
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpGet("getappointmentdetailsbydoctorid")]
    public IActionResult GetAppointmentDetailsByDoctorId(int doctorId)
    {
      var result = _appointmentService.GetAppointmentDetailsByDoctor(doctorId);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpGet("getappointmentdetailsbypatientid")]
    public IActionResult GetAppointmentDetailsByPatientId(int patientId)
    {
      var result = _appointmentService.GetAppointmentDetailsByPatient(patientId);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpGet("getappointmentdetailsbydate")]
    public IActionResult GetAppointmentDetailsByDate(DateTime date)
    {
      var result = _appointmentService.GetAppointmentDetailsByDate(date);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
  }
}
