using System;
using System.Collections.Generic;
using System.Text;

namespace TAO_Core.CrossCuttingConcerns.Logging
{
  public class LogDetail
  {
    public string MethodName { get; set; }
    public List<LogParameter> LogParameters { get; set; }

  }
}
