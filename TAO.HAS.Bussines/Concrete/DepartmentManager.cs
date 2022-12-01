using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Business.BusinessAspects;
using TAO.HAS.Business.Constans;
using TAO.HAS.Business.ValidationRules.FluentValidation;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
using TAO_Core.Aspects.Autofac.Caching;
using TAO_Core.Aspects.Autofac.Performance;
using TAO_Core.Aspects.Autofac.Validation;
using TAO_Core.Utilities.Business;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;

namespace TAO.HAS.Business.Concrete
{
  public class DepartmentManager : IDepartmentService
  {
    IDepartmentDal _departmentDal;
    public DepartmentManager(IDepartmentDal departmentDal)
    {
      _departmentDal = departmentDal;
    }
    [SecuredOperation("admin,department.add")]
    [PerformanceAspect(10)]
    [CacheRemoveAspect("IDepartmentService.Get")]
    [ValidationAspect(typeof(DepartmentValidator))]
    public IResult Add(Department department)
    {
      var result = BusinessRules.Run(CheckIfDepartmentLimitExceded());
      if (result != null)
      {
        return result;
      }
      _departmentDal.Add(department);
      return new SuccessResult(Messages.DepartmentAdded);
    }

    [SecuredOperation("admin,department.update")]
    public IResult Delete(Department department)
    {
      _departmentDal.Delete(department);
      return new SuccessResult(Messages.DepartmentDeleted);
    }
    [CacheAspect]
    [PerformanceAspect(10)]

    public IDataResult<List<Department>> GetAll()
    {
      return new SuccessDataResult<List<Department>>(_departmentDal.GetAll(), Messages.DepartmentsListed);
    }
    [CacheAspect]
    [PerformanceAspect(10)]

    public IDataResult<List<Department>> GetById(int departmentId)
    {
      return new SuccessDataResult<List<Department>>(_departmentDal.GetAll(d => d.Id == departmentId), Messages.DepartmentsListed);
    }

    [SecuredOperation("admin,department.update")]
    [ValidationAspect(typeof(DepartmentValidator))]
    public IResult Update(Department department)
    {
      _departmentDal.Update(department);
      return new SuccessResult(Messages.DepartmentUpdated);
    }
    #region BusinessRules
    private IResult CheckIfDepartmentLimitExceded()
    {
      var result = _departmentDal.GetAll().Count;
      if (result > 35)
      {
        return new ErrorResult(Messages.DepartmentLimitExceded);
      }
      return new SuccessResult();
    }
    #endregion
  }
}
