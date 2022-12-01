using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Entities.Concrete;

namespace TAO.HAS.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DoctorsController : ControllerBase
  {
    IDoctorService _doctorService;
    public DoctorsController(IDoctorService doctorService)
    {
      _doctorService = doctorService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
      var result = _doctorService.GetAll();
      if(result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("getbydepartmentid")]
    public IActionResult GetByDepartmentId(int departmentId)
    {
      var result = _doctorService.GetByDepartment(departmentId);
      if(result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("getbyproffesionid")]
    public IActionResult GetByProffesionId(int proffesionId)
    {
      var result = _doctorService.GetByProffesion(proffesionId);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpPost("add")]
    public IActionResult Add(Doctor doctor)
    {
      var result = _doctorService.Add(doctor);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpPost("update")]
    public IActionResult Update(Doctor doctor)
    {
      var result = _doctorService.Update(doctor);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpPost("delete")]
    public IActionResult Delete(Doctor doctor)
    {
      var result = _doctorService.Delete(doctor);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
  }
}
