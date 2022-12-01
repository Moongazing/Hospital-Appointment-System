using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAO.HAS.Business.Abstract;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;

namespace TAO.HAS.WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DepartmentsController : ControllerBase
  {
    IDepartmentService _departmentService;
    public DepartmentsController(IDepartmentService departmentService)
    {
      _departmentService = departmentService;
    }
    [HttpPost("add")]
    public IActionResult Add(Department department)
    {
      var result = _departmentService.Add(department);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpPost("update")]
    public IActionResult Update(Department department)
    {
      var result = _departmentService.Update(department);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpPost("delete")]
    public IActionResult Delete(Department department)
    {
      var result = _departmentService.Delete(department);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
      var result = _departmentService.GetAll();
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int departmentId)
    {
      var result = _departmentService.GetById(departmentId);
      if (result.Success)
      {
        return Ok(result);
      }
      return BadRequest(result);
    }

  }
}
