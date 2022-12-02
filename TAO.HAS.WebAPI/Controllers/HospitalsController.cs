using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Entities.Concrete;

namespace TAO.HAS.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HospitalsController : ControllerBase
  {

    IHospitalService _hospitalService;
    public HospitalsController(IHospitalService hospitalService)
    {
      _hospitalService = hospitalService;
    }
    [HttpPost("add")]
    public IActionResult Add(Hospital hospital)
    {
      var result = _hospitalService.Add(hospital);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpPost("update")]
    public IActionResult Update(Hospital hospital)
    {
      var result = _hospitalService.Update(hospital);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpPost("delete")]
    public IActionResult Delete(Hospital hospital)
    {
      var result = _hospitalService.Delete(hospital);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
      var result = _hospitalService.GetAll();
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("getbylocationid")]
    public IActionResult GetByLocationId(int locationId)
    {
      var result = _hospitalService.GetByLocationId(locationId);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
   

  }
}
