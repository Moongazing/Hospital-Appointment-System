using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Business.BusinessAspects;
using TAO.HAS.Business.Constans;
using TAO.HAS.Business.ValidationRules.FluentValidation;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
using TAO.HAS.Entities.DTOs;
using TAO_Core.Aspects.Autofac.Caching;
using TAO_Core.Aspects.Autofac.Logging;
using TAO_Core.Aspects.Autofac.Performance;
using TAO_Core.Aspects.Autofac.Validation;
using TAO_Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using TAO_Core.Utilities.Business;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;

namespace TAO.HAS.Business.Concrete
{
  public class DoctorManager : IDoctorService
  {
    IDoctorDal _doctorDal;
    IDepartmentService _departmentService;

    public DoctorManager(IDoctorDal doctorDal,IDepartmentService departmentService)
    {
      _doctorDal = doctorDal;
      _departmentService = departmentService;
      
    }
    [ValidationAspect(typeof(DoctorValidator))]
    [SecuredOperation("admin,doctor.add")]
    [PerformanceAspect(10)]
    [LogAspect(typeof(DatabaseLogger))]
    [CacheRemoveAspect("IDoctorService.Get")]
    public IResult Add(Doctor doctor)
    {
      var result = BusinessRules.Run(CheckIfDoctorAge(doctor.BirthDate),
                                     CheckIfDoctorMailIsExists(doctor.Email),
                                     CheckIfDepartmentLimitExceded(),
                                     CheckIfStatusPassive(doctor.Status)
                                     );
      if(result != null )
      {
        return result;
      }
      _doctorDal.Add(doctor);
      return new SuccessResult(Messages.DoctorAdded);
    }

    [SecuredOperation("admin,doctor.delete")]
    [CacheAspect]
    [PerformanceAspect(10)]
    [LogAspect(typeof(FileLogger))]
    public IResult Delete(Doctor doctor)
    {
      _doctorDal.Delete(doctor);
      return new SuccessResult(Messages.DoctorDeleted);
    }
    [LogAspect(typeof(FileLogger))]
    [CacheAspect]
    [PerformanceAspect(12)]
    public IDataResult<List<Doctor>> GetAll()
    {
      return new DataResult<List<Doctor>>(_doctorDal.GetAll(), true, Messages.DoctorsListed);
    }
    [CacheAspect]
    [PerformanceAspect(12)]
    [LogAspect(typeof(FileLogger))]
    public IDataResult<List<DoctorDetailDto>> GetDoctorDetails()
    {
     return new DataResult<List<DoctorDetailDto>>(_doctorDal.GetDoctorDetails(),true,Messages.DoctorDetailsListed);
    }
    [CacheAspect]
    [PerformanceAspect(12)]
    [LogAspect(typeof(FileLogger))]
    public IDataResult<List<Doctor>> GetByDepartment(int departmentId)
    {
      return new SuccessDataResult<List<Doctor>>(_doctorDal.GetAll(d => d.DepartmentId == departmentId));
    }
    [CacheAspect]
    [PerformanceAspect(12)]
    [LogAspect(typeof(FileLogger))]
    public IDataResult<List<Doctor>> GetByProffesion(int proffesionId)
    {
      return new SuccessDataResult<List<Doctor>>(_doctorDal.GetAll(d => d.ProffesionId == proffesionId));
    }

    [ValidationAspect(typeof(DoctorValidator))]
    [SecuredOperation("admin,doctor.update")]
    [CacheAspect]
    [PerformanceAspect(12)]
    [LogAspect(typeof(DatabaseLogger))]
    public IResult Update(Doctor doctor)
    {
      _doctorDal.Update(doctor);
      return new SuccessResult(Messages.DoctorUpdated);
    }

    #region BusinessRules
    private IResult CheckIfDoctorAge(DateTime birthDate)
    {
      var result = _doctorDal.GetAll(d => d.BirthDate.Year <= 1980);
      return new ErrorResult(Messages.DoctorAgeIsNotValid);
    }
    
    private IResult CheckIfDoctorMailIsExists(string email)
    {
      var result = _doctorDal.GetAll(d => d.Email == email).Count;
      if(result > 0)
      {
        return new ErrorResult(Messages.EmailIsAlreadyExists);
      }
      return new SuccessResult();
    }
    private IResult CheckIfDepartmentLimitExceded()
    {
      var result = _departmentService.GetAll();
      if(result.Data.Count > 120)
      {
        return new ErrorResult(Messages.DepartmentLimitExceded);
      }
      return new SuccessResult();
    }
    private IResult CheckIfStatusPassive(bool status)
    {

      var result = _doctorDal.GetAll(d => d.Status == false);
      var result2 = _doctorDal.GetAll(d => d.Status == status);
      if(result == result2)
      {
        return new ErrorResult(Messages.StatusShouldBeActive);
      }
      return new SuccessResult();
    }
    #endregion


  }
}
