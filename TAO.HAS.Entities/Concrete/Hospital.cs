using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Entities;

namespace TAO.HAS.Entities.Concrete
{
  public class Hospital:IEntity
  {
    public int Id { get; set; }
    public int LocationId { get; set; }
    public string HospitalName { get; set; }
    public int Capacity { get; set; }
  }
}
