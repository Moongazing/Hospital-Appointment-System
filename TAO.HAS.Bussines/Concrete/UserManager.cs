using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Business.Constans;
using TAO_Core.Aspects.Autofac.Validation;
using TAO_Core.Entities.Concrete;
using TAO_Core.Utilities.Business;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;
using TAO_Core.Utilities.Results;
using TAO.HAS.DataAccess.Abstract;

namespace TAO.HAS.Business.Concrete
{
  public class UserManager : IUserService
  {
    IUserDal _userDal;
    public UserManager(IUserDal userDal)
    {
      _userDal = userDal;
    }
   
    public IResult Add(User user)
    {
      _userDal.Add(user);
      return new SuccessResult(Messages.UserAdded);
    }

    public IResult Delete(User user)
    {
      _userDal.Delete(user);
      return new SuccessResult(Messages.UserDeleted);
    }

    public IDataResult<List<User>> GetAll()
    {
      return new SuccessDataResult<List<User>>(_userDal.GetAll());
    }

    public User GetByMail(string email)
    {
      return _userDal.Get(u => u.Email == email);
    }

    public List<OperationClaim> GetClaims(User user)
    {
      return _userDal.GetClaims(user);
    }

    public IDataResult<User> GetUser(int userId)
    {
      return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
    }


    public IResult Update(User user)
    {
      _userDal.Add(user);
      return new SuccessResult(Messages.UserUpdated);
    }


  }
}
