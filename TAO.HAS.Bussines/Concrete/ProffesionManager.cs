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
  public class ProffesionManager : IProffesionService
  {
    IProffesionDal _proffesionDal;
    public ProffesionManager(IProffesionDal proffesionDal)
    {
      _proffesionDal = proffesionDal;
    }

    public IResult Add(Proffesion proffesion)
    {
      throw new NotImplementedException();
    }

    public IResult Delete(Proffesion proffesion)
    {
      throw new NotImplementedException();
    }

    public IDataResult<List<Proffesion>> GetAll()
    {
      throw new NotImplementedException();
    }

    public IResult Update(Proffesion proffesion)
    {
      throw new NotImplementedException();
    }
  }
}
