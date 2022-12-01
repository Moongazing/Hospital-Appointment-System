using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Entities;

namespace TAO.HAS.Entities.Concrete
{
  public class Doctor:IEntity
  {
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public int ProffesionId { get; set; }
    public int LocationId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public int Sex { get; set; }
    public bool Status { get; set; }
  }
}
