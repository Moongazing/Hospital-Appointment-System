using System;
using System.Collections.Generic;
using System.Text;

namespace TAO_Core.Utilities.Results.Abstract
{
  public interface IDataResult<T>:IResult
  {
    T Data { get; }
  }
}
