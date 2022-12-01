using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using TAO_Core.Utilities.Interceptors;

namespace TAO_Core.Aspects.Autofac.Transaction
{
  public class TransactionScopeAspect : MethodInterception
  {
    public override void Intercept(IInvocation invocation)
    {
      using (TransactionScope transactionScope = new TransactionScope())
      {
        try
        {
          invocation.Proceed();
          transactionScope.Complete();
        }
        catch (System.Exception e)
        {
          transactionScope.Dispose();
          throw;
        }
      }
    }
  }
}
