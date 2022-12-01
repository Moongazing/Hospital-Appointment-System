using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
using TAO_Core.DataAccess.EntityFramework;

namespace TAO.HAS.DataAccess.Concrete.EntityFramework
{
  public class EfLocationDal :EfEntityRepositoryBase<Location,HospitalAppointmentSystemContext>,ILocationDal
  {
  }
}
