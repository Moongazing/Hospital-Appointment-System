using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Entities;

namespace TAO.HAS.Entities.Concrete
{
  public class Patient : IEntity
  {
    public int Id { get; set; }
    public string TCNK { get; set; }  //National Identity For Turkey
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BloodType { get; set; }
    public float Height { get; set; }
    public float Weight { get; set; }
    public bool Allergy { get; set; }
    public string AllergyInfo { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }



  }
}
