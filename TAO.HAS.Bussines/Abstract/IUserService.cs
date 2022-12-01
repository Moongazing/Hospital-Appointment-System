using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Entities.Concrete;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results;

namespace TAO.HAS.Business.Abstract
{
  public interface IUserService
  {
    IDataResult<List<User>> GetAll();
    IDataResult<User> GetUser(int userId);
    IResult Add(User user);
    IResult Delete(User user);
    IResult Update(User user);
    List<OperationClaim> GetClaims(User user);
    //IDataResult<User> GetByMail(string email);
    User GetByMail(string email);
  }
}
