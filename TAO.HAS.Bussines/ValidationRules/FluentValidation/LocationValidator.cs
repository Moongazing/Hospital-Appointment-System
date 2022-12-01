using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;

namespace TAO.HAS.Business.ValidationRules.FluentValidation
{
  public class LocationValidator:AbstractValidator<Location>
  {
    public LocationValidator()
    {
      RuleFor(l=>l.City).NotEmpty();
      RuleFor(l => l.Country).NotEmpty();
      RuleFor(l => l.Description).NotEmpty();
    }
  }
}
