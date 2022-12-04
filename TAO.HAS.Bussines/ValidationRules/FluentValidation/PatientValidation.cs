using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;

namespace TAO.HAS.Business.ValidationRules.FluentValidation
{
  public class PatientValidation : AbstractValidator<Patient>
  {
    public PatientValidation()
    {
      RuleFor(p => p.TCNK).NotEmpty();
      RuleFor(p => p.FirstName).NotEmpty();
      RuleFor(p => p.LastName).NotEmpty();
      RuleFor(p => p.Email).NotEmpty();
      RuleFor(p => p.PhoneNumber).NotEmpty();
      RuleFor(p => p.Allergy).NotEmpty();
      RuleFor(p => p.Weight).NotEmpty();
      RuleFor(p => p.Height).NotEmpty();
      RuleFor(p => p.BirthDate).NotEmpty();
      RuleFor(p => p.BloodType).NotEmpty();

      RuleFor(p => p.Email).EmailAddress();
      RuleFor(p => p.Weight).GreaterThan(0);
      RuleFor(p => p.Height).GreaterThan(0);
      RuleFor(p => p.FirstName).MinimumLength(2); 
      RuleFor(p => p.LastName).MinimumLength(2);
      RuleFor(p => p.PhoneNumber).MaximumLength(11).MinimumLength(11);
    }
  }
}
