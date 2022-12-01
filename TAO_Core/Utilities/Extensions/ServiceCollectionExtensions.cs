using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TAO_Business.DependencyResolvers.Autofac;
using TAO_Core.Utilities.IoC;

namespace TAO_Core.Utilities.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
    {
      foreach (var module in modules)
      {
        module.Load(serviceCollection);
      }
      return ServiceTool.Create(serviceCollection);
    }
  }
}
