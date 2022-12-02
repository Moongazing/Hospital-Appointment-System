using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results;

namespace TAO.HAS.Business.Abstract
{
  public interface IHospitalService
  {
    IResult Add(Hospital hospital);
    IResult Delete(Hospital hospital);
    IResult Update(Hospital hospital);
    IDataResult<List<Hospital>> GetAll();
    IDataResult<List<Hospital>> GetByLocationId(int locationId);
  }
}
