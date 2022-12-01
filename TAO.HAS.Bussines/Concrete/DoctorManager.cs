using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Business.Abstract;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
using TAO.HAS.Entities.DTOs;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;

namespace TAO.HAS.Business.Concrete
{
  public class DoctorManager : IDoctorService
  {
    IDoctorDal _doctorDal;
    public DoctorManager(IDoctorDal doctorDal)
    {
      _doctorDal = doctorDal;
    }
    public IResult Add(Doctor doctor)
    {
      throw new NotImplementedException();
    }

    public IResult Delete(Doctor doctor)
    {
      throw new NotImplementedException();
    }

    public IDataResult<List<Doctor>> GetAll()
    {
      throw new NotImplementedException();
    }

    public IDataResult<List<DoctorDetailDto>> GetDoctorDetails()
    {
      throw new NotImplementedException();
    }

    public IResult Update(Doctor doctor)
    {
      throw new NotImplementedException();
    }

    /*Business Rules */

  }
}
