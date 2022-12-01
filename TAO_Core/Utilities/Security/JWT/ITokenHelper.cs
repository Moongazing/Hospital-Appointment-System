using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Entities.Concrete;

namespace TAO_Core.Utilities.Security.JWT
{
  public interface ITokenHelper
  {
    AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
  }
}
