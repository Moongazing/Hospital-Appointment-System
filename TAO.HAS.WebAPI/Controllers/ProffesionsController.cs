using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Entities.Concrete;

namespace TAO.HAS.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProffesionsController : ControllerBase
  {
    IProffesionService _proffesionService;
    public ProffesionsController(IProffesionService proffesionService)
    {
      _proffesionService = proffesionService;
    }
    [HttpPost("add")]
    public IActionResult Add(Proffesion proffesion)
    {
      var result = _proffesionService.Add(proffesion);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpPost("update")]
    public IActionResult Update(Proffesion proffesion)
    {
      var result = _proffesionService.Update(proffesion);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpPost("delete")]
    public IActionResult Delete(Proffesion proffesion)
    {
      var result = _proffesionService.Delete(proffesion);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
      var result = _proffesionService.GetAll();
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
  }
}
