using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Business.Constans;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
using TAO.HAS.Entities.DTOs;
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
    public IResult Add(Doctor doctor)
    {
      var result = BusinessRules.Run(CheckIfDoctorAge(doctor.BirthDate),
                                     CheckIfDoctorMailIsExists(doctor.Email),
                                     CheckIfDepartmentLimitExceded()
                                     );
      if(result != null )
      {
        return result;
      }
      _doctorDal.Add(doctor);
      return new SuccessResult(Messages.DoctorAdded);
    }

    public IResult Delete(Doctor doctor)
    {
      _doctorDal.Delete(doctor);
      return new SuccessResult(Messages.DoctorDeleted);
    }

    public IDataResult<List<Doctor>> GetAll()
    {
      return new DataResult<List<Doctor>>(_doctorDal.GetAll(), true, Messages.DoctorsListed);
    }

    public IDataResult<List<DoctorDetailDto>> GetDoctorDetails()
    {
     return new DataResult<List<DoctorDetailDto>>(_doctorDal.GetDoctorDetails(),true,Messages.DoctorDetailsListed);
    }
    public IDataResult<List<Doctor>> GetByDepartment(int departmentId)
    {
      return new SuccessDataResult<List<Doctor>>(_doctorDal.GetAll(d => d.DepartmentId == departmentId));
    }

    public IDataResult<List<Doctor>> GetByProffesion(int proffesionId)
    {
      return new SuccessDataResult<List<Doctor>>(_doctorDal.GetAll(d => d.ProffesionId == proffesionId));
    }

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

  
    #endregion


  }
}
