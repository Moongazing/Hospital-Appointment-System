using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Business.Constans;
using TAO_Core.Utilities.Extensions;
using TAO_Core.Utilities.Interceptors;
using TAO_Core.Utilities.IoC;

namespace TAO.HAS.Business.BusinessAspects
{
  public class SecuredOperation : MethodInterception
  {
    private string[] _roles;
    private IHttpContextAccessor _httpContextAccessor;

    public SecuredOperation(string roles)
    {
      _roles = roles.Split(',');
      _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

    }

    protected override void OnBefore(IInvocation invocation)
    {
      var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
      foreach (var role in _roles)
      {
        if (roleClaims.Contains(role))
        {
          return;
        }
      }
      throw new Exception(); //Messages.AuthorizationDenied
    }
  }
}
