using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core;

namespace TAO.HAS.Entities.DTOs
{
  public class UserForRegisterDto : IDto
  {
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}
