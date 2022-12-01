using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;
using TAO_Core.DataAccess;
using TAO_Core.DataAccess.EntityFramework;

namespace TAO.HAS.DataAccess.Abstract
{
  public interface ILocationDal:IEntityRepository<Location>
  {
  }
}
