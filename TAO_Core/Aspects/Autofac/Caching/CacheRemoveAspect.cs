using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.CrossCuttingConcerns.Caching;
using TAO_Core.Utilities.Interceptors;
using TAO_Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace TAO_Core.Aspects.Autofac.Caching
{
  public class CacheRemoveAspect : MethodInterception
  {
    private string _pattern;
    private ICacheManager _cacheManager;

    public CacheRemoveAspect(string pattern)
    {
      _pattern = pattern;
      _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    }

    protected override void OnSuccess(IInvocation invocation)
    {
      _cacheManager.RemoveByPattern(_pattern);
    }
  }
}
