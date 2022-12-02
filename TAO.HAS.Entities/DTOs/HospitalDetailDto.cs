using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core;

namespace TAO.HAS.Entities.DTOs
{
  public class HospitalDetailDto:IDto
  {
    public int HospitalId { get; set; }
    public int LocationId { get; set; }
    public string HospitalName { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public int Capacity { get; set; }
  }
}
