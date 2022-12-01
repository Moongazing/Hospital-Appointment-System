using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TAO_Business.DependencyResolvers.Autofac;
using TAO_Core.CrossCuttingConcerns.Caching;
using TAO_Core.CrossCuttingConcerns.Caching.Microsoft;
using TAO_Core.Utilities.IoC;


namespace TAO_Core.DependencyResolvers
{
  public class CoreModule : ICoreModule
  {
    public void Load(IServiceCollection serviceCollection)
    {
      serviceCollection.AddMemoryCache();
      serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
      serviceCollection.AddSingleton<Stopwatch>();
    }
  }
}
