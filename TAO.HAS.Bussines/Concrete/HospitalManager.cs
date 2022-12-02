using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Business.Abstract;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;

namespace TAO.HAS.Business.Concrete
{
  public class HospitalManager : IHospitalService
  {
    IHospitalDal _hospitalDal;
    public HospitalManager(IHospitalDal hospitalDal)
    {
      _hospitalDal = hospitalDal;
    }

    public IResult Add(Hospital hospital)
    {
      throw new NotImplementedException();
    }

    public IResult Delete(Hospital hospital)
    {
      throw new NotImplementedException();
    }

    public IDataResult<List<Hospital>> GetAll()
    {
      throw new NotImplementedException();
    }

    public IDataResult<List<Hospital>> GetByLocationId(int locationId)
    {
      throw new NotImplementedException();
    }

    public IResult Update(Hospital hospital)
    {
      throw new NotImplementedException();
    }
  }
}
