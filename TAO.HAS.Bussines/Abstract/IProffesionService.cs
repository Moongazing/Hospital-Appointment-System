using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results;

namespace TAO.HAS.Business.Abstract
{
  public interface IProffesionService
  {
    IResult Add(Proffesion proffesion);
    IResult Delete(Proffesion proffesion);
    IResult Update(Proffesion proffesion);
    IDataResult<List<Proffesion>> GetAll();
  }
}
