using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Business.Constans;
using TAO.HAS.Business.ValidationRules.FluentValidation;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
using TAO.HAS.Entities.DTOs;
using TAO_Core.Aspects.Autofac.Validation;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;

namespace TAO.HAS.Business.Concrete
{
  public class HospitalManager : IHospitalService
  {
    IHospitalDal _hospitalDal;
    public HospitalManager(IHospitalDal hospitalDal)
    {
      _hospitalDal = hospitalDal;
    }
    [ValidationAspect(typeof(HospitalValidator))]
    public IResult Add(Hospital hospital)
    {
      _hospitalDal.Add(hospital);
      return new SuccessResult(Messages.HospitalAdded);
    }

    public IResult Delete(Hospital hospital)
    {
      _hospitalDal.Delete(hospital);
      return new SuccessResult(Messages.HospitalDeleted);
    }

    public IDataResult<List<Hospital>> GetAll()
    {
      return new SuccessDataResult<List<Hospital>>(_hospitalDal.GetAll(), Messages.HospitalsListed);
    }

    public IDataResult<List<Hospital>> GetByLocationId(int locationId)
    {
      return new SuccessDataResult<List<Hospital>>(_hospitalDal.GetAll(h => h.LocationId == locationId), Messages.HospitalsListed);
    }

    public IDataResult<List<HospitalDetailDto>> GetHospitalDetails()
    {
      return new SuccessDataResult<List<HospitalDetailDto>>(_hospitalDal.GetHospitalDetails(), Messages.HospitalDetailsListed);
    }

    [ValidationAspect(typeof(HospitalValidator))]
    public IResult Update(Hospital hospital)
    {
      _hospitalDal.Update(hospital);
      return new SuccessResult(Messages.HospitalUpdated);
    }
  }
}
