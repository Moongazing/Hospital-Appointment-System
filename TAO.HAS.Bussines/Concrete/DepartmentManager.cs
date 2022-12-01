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
  public class DepartmentManager : IDepartmentService
  {
    IDepartmentDal _departmentDal;
    public DepartmentManager(IDepartmentDal departmentDal)
    {
      _departmentDal = departmentDal;
    }

    public IResult Add(Department department)
    {
      throw new NotImplementedException();
    }

    public IResult Delete(Department department)
    {
      throw new NotImplementedException();
    }

    public IDataResult<List<Department>> GetAll()
    {
      throw new NotImplementedException();
    }

    public IResult Update(Department department)
    {
      throw new NotImplementedException();
    }
    #region BusinessRules
    #endregion
  }
}
