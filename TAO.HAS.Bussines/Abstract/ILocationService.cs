using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results;

namespace TAO.HAS.Business.Abstract
{
  public interface ILocationService
  {
    IResult Add(Location location);
    IResult Delete(Location location);
    IResult Update(Location location);
    IDataResult<List<Location>> GetAll();
    IDataResult<List<Location>> GetByCountry(string country);  
    IDataResult<List<Location>> GetByCity(string city);
  }
}
