using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TAO_Business.DependencyResolvers.Autofac
{
  public interface ICoreModule
  {
    void Load(IServiceCollection serviceCollection);
  }
}
