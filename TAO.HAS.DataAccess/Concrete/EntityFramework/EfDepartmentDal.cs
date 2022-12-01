using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
using TAO_Core.DataAccess.EntityFramework;

namespace TAO.HAS.DataAccess.Concrete.EntityFramework
{
  public class EfDepartmentDal: EfEntityRepositoryBase<Department, HospitalAppointmentSystemContext>, IDepartmentDal
  {
  }
}
