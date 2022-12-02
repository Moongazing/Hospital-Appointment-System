using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Business.Constans;
using TAO.HAS.Business.ValidationRules.FluentValidation;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
using TAO_Core.Aspects.Autofac.Caching;
using TAO_Core.Aspects.Autofac.Validation;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;

namespace TAO.HAS.Business.Concrete
{
  public class LocationManager : ILocationService
  {
    ILocationDal _locationDal;
    public LocationManager(ILocationDal locationDal)
    {
      _locationDal = locationDal; 
    }
    [ValidationAspect(typeof(LocationValidator))]
    public IResult Add(Location location)
    {
      _locationDal.Add(location);
      return new SuccessResult(Messages.LocationAdded);
    }

    public IResult Delete(Location location)
    {
      _locationDal.Delete(location);
      return new SuccessResult(Messages.LocationDeleted);
    }
    [CacheAspect]
    public IDataResult<List<Location>> GetAll()
    {
      return new SuccessDataResult<List<Location>>(_locationDal.GetAll(),Messages.LocationsListed);
    }
    [CacheAspect]
    public IDataResult<List<Location>> GetByCity(string city)
    {
      return new SuccessDataResult<List<Location>>(_locationDal.GetAll(l => l.City == city), Messages.LocationsListed);

    }
    [CacheAspect]
    public IDataResult<List<Location>> GetByCountry(string country)
    {
      return new SuccessDataResult<List<Location>>(_locationDal.GetAll(l => l.Country == country),Messages.LocationsListed);
    }

    [ValidationAspect(typeof(LocationValidator))]
    public IResult Update(Location location)
    {
      _locationDal.Update(location);
      return new SuccessResult(Messages.LocationUpdated);
    }

    #region Bussiness Rules

    #endregion
  }
}
