using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
  }
}
