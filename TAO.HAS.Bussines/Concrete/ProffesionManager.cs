using System;
using System.Collections.Generic;
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
  public class ProffesionManager : IProffesionService
  {
    IProffesionDal _proffesionDal;
    public ProffesionManager(IProffesionDal proffesionDal)
    {
      _proffesionDal = proffesionDal;
    }
    [CacheRemoveAspect("IProffesionService.Get")]
    [ValidationAspect(typeof(ProffesionValidator))]
    public IResult Add(Proffesion proffesion)
    {
      _proffesionDal.Add(proffesion);
      return new SuccessResult(Messages.ProffesionAdded);
    }

    public IResult Delete(Proffesion proffesion)
    {
      _proffesionDal.Delete(proffesion);
      return new SuccessResult(Messages.ProffesionDeleted);
    }
    [CacheAspect]
    public IDataResult<List<Proffesion>> GetAll()
    {
      return new SuccessDataResult<List<Proffesion>>(_proffesionDal.GetAll(),Messages.ProfessionsListed);
    }
    [ValidationAspect(typeof(ProffesionValidator))]
    public IResult Update(Proffesion proffesion)
    {
      _proffesionDal.Update(proffesion);
      return new SuccessResult(Messages.ProffesionUpdated);
    }
  }
}
