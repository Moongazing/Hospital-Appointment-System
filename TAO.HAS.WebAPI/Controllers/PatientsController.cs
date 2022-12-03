using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Entities.Concrete;

namespace TAO.HAS.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PatientsController : ControllerBase
  {
    IPatientService _patientService;
    public PatientsController(IPatientService patientService)
    {
      _patientService = patientService;
    }
    [HttpPost("add")]
    public IActionResult Add(Patient patient)
    {
      var result = _patientService.Add(patient);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpPost("update")]
    public IActionResult Update(Patient patient)
    {
      var result = _patientService.Update(patient);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpPost("delete")]
    public IActionResult Delete(Patient patient)
    {
      var result = _patientService.Delete(patient);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
      var result = _patientService.GetAll();
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("getbybloodtype")]
    public IActionResult GetByBloodType(string bloodType)
    {
      var result = _patientService.GetByBloodType(bloodType);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpGet("getbyage")]
    public IActionResult GetByAge(DateTime maxYear, DateTime minYear)
    {
      var result = _patientService.GetByBirthYear(maxYear,minYear);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
  }
}
