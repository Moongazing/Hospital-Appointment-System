using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Utilities.Results;

namespace TAO_Core.Utilities.Business
{
  public class BusinessRules
  {
    public static IResult Run(params IResult[] logigcs)
    {
      foreach (var logic in logigcs)
      {
        if (!logic.Success)
        {
          return logic;
        }
      }
      return null;
    }
  }
}
