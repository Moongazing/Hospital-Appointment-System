using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.DataAccess;
using TAO_Core.Entities.Concrete;

namespace TAO.HAS.DataAccess.Abstract
{
  public interface IUserDal : IEntityRepository<User>
  {
    List<OperationClaim> GetClaims(User user);

  }
}
