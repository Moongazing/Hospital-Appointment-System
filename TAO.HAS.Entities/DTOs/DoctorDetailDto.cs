using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using TAO_Core;

namespace TAO.HAS.Entities.DTOs
{
  public class DoctorDetailDto:IDto
  {
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public int ProffesionId { get; set; }
    public int LocationId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string Department { get; set; }
    public string Proffesion { get; set; }
    public string Location { get; set; }
    public int Sex { get; set; }
    public bool Status { get; set; }
  }
}
