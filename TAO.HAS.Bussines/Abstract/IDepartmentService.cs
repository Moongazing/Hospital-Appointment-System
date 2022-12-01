using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results;

namespace TAO.HAS.Business.Abstract
{
  internal interface IDepartmentService
  {
    IResult Add(Department department);
    IResult Delete(Department department);
    IResult Update(Department department);
    IDataResult<List<Department>> GetAll();
  }
}
