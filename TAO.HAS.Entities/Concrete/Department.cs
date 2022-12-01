using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Entities;

namespace TAO.HAS.Entities.Concrete
{
  public class Department:IEntity
  {
    public int Id { get; set; }
    public string Description  { get; set; }
  }
}
