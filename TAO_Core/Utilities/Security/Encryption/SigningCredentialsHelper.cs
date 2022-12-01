using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace TAO_Core.Utilities.Security.Encryption
{
  public class SigningCredentialsHelper
  {
    public static SigningCredentials CreateSigninCredentials(SecurityKey securityKey)
    {
      return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
    }
  }
}
