using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.CrossCuttingConcerns.Logging.Log4Net;
using TAO_Core.CrossCuttingConcerns.Logging;
using TAO_Core.Utilities.Interceptors;

namespace TAO_Core.Aspects.Autofac.Logging
{
  public class LogAspect : MethodInterception
  {
    private LoggerServiceBase _loggerServiceBase;

    public LogAspect(Type loggerService)
    {
      if (loggerService.BaseType != typeof(LoggerServiceBase))
      {
        throw new System.Exception("Wrong Logger Type!");
      }

      _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
    }

    protected override void OnBefore(IInvocation invocation)
    {
      _loggerServiceBase.Info(GetLogDetail(invocation));
    }

    private LogDetail GetLogDetail(IInvocation invocation)
    {
      var logParameters = new List<LogParameter>();
      for (int i = 0; i < invocation.Arguments.Length; i++)
      {
        logParameters.Add(new LogParameter
        {
          Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
          Value = invocation.Arguments[i],
          Type = invocation.Arguments[i].GetType().Name
        });
      }

      var logDetail = new LogDetail
      {
        MethodName = invocation.Method.Name,
        LogParameters = logParameters
      };

      return logDetail;
    }
  }
}
