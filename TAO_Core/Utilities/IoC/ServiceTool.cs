using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TAO_Core.Utilities.IoC
{
  public static class ServiceTool
  {
    public static IServiceProvider ServiceProvider { get; private set; }

    public static IServiceCollection Create(IServiceCollection services)
    {
      ServiceProvider = services.BuildServiceProvider();
      return services;
    }
  }
}
