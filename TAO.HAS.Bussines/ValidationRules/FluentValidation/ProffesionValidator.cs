using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;

namespace TAO.HAS.Business.ValidationRules.FluentValidation
{
  public class ProffesionValidator : AbstractValidator<Proffesion>
  {
    public ProffesionValidator()
    {
      RuleFor(p => p.Description).NotEmpty();
    }
  }
}
