using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAO.HAS.Business.Abstract;
using TAO_Core.Entities.Concrete;

namespace TAO.HAS.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    IUserService _userService;
    public UsersController(IUserService userService)
    {
      _userService = userService;
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
      var result = _userService.GetAll();
      if (result.Success)
      {
        return Ok(result.Data);
      }
      return BadRequest(result.Message);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int userId)
    {
      var result = _userService.GetUser(userId);
      if (result.Success)
      {
        return Ok(result.Data);
      }
      return BadRequest(result.Message);
    }

    [HttpGet("add")]
    public IActionResult Add(User user)
    {
      var result = _userService.Add(user);
      if (result.Success)
      {
        return Ok(result.Message);
      }
      return BadRequest(result.Message);
    }
    [HttpGet("delete")]
    public IActionResult Delete(User user)
    {
      var result = _userService.Delete(user);
      if (result.Success)
      {
        return Ok(result.Message);
      }
      return BadRequest(result.Message);
    }

    [HttpGet("update")]
    public IActionResult Update(User user)
    {
      var result = _userService.Add(user);
      if (result.Success)
      {
        return Ok(result.Message);
      }
      return BadRequest(result.Message);
    }
  }
}
