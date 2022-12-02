using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Entities.Concrete;

namespace TAO.HAS.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LocationsController : ControllerBase
  {
    ILocationService _locationService;
    public LocationsController(ILocationService locationService)
    {
      _locationService = locationService;
    }
    [HttpPost("add")]
    public IActionResult Add(Location location)
    {
      var result = _locationService.Add(location);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpPost("update")]
    public IActionResult Update(Location location)
    {
      var result = _locationService.Update(location);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpPost("delete")]
    public IActionResult Delete(Location location)
    {
      var result = _locationService.Delete(location);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
      var result = _locationService.GetAll();
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("getbycountry")]
    public IActionResult GetByCountry(string country)
    {
      var result = _locationService.GetByCountry(country);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpGet("getbycity")]
    public IActionResult GetByCity(string city)
    {
      var result = _locationService.GetByCountry(city);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
  }
}
