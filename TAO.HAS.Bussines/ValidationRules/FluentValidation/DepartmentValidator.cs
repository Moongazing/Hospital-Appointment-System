using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;

namespace TAO.HAS.Business.ValidationRules.FluentValidation
{
  public class DepartmentValidator:AbstractValidator<Department>
  {
    public DepartmentValidator()
    {
      RuleFor(d => d.Description).NotEmpty();
      RuleFor(d => d.Description).MinimumLength(5).MinimumLength(30);
    }
  }
}
