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
  public class LocationManager : ILocationService
  {
    ILocationDal _locationDal;
    public LocationManager(ILocationDal locationDal)
    {
      _locationDal = locationDal; 
    }
    public IResult Add(Location location)
    {
      throw new NotImplementedException();
    }

    public IResult Delete(Location location)
    {
      throw new NotImplementedException();
    }

    public IDataResult<List<Location>> GetAll()
    {
      throw new NotImplementedException();
    }

    public IResult Update(Location location)
    {
      throw new NotImplementedException();
    }
  }
}
