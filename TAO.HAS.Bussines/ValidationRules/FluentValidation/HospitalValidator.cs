
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;

namespace TAO.HAS.Business.ValidationRules.FluentValidation
{
  public class HospitalValidator:AbstractValidator<Hospital>
  {
    public HospitalValidator()
    {
      RuleFor(h => h.HospitalName).NotEmpty();
      RuleFor(h => h.LocationId).NotEmpty();
      RuleFor(h => h.Capacity).NotEmpty();
    }
  }
}
