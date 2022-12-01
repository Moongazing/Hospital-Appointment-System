using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;
using TAO.HAS.Entities.DTOs;
using TAO_Core.DataAccess;

namespace TAO.HAS.DataAccess.Abstract
{
  public interface IDoctorDal : IEntityRepository<Doctor>
  {
    public List<DoctorDetailDto> GetDoctorDetails();
  }
}
