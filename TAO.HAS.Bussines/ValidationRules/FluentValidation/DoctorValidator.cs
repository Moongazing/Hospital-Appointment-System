using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;

namespace TAO.HAS.Business.ValidationRules.FluentValidation
{
  public class DoctorValidator : AbstractValidator<Doctor>
  {
    public DoctorValidator()
    {
      RuleFor(d => d.FirstName).NotEmpty();
      RuleFor(d => d.LastName).NotEmpty();
      RuleFor(d => d.DepartmentId).NotEmpty();
      RuleFor(d => d.ProffesionId).NotEmpty();
      RuleFor(d => d.Email).NotEmpty();
      RuleFor(d => d.Status).NotEmpty();
      RuleFor(d => d.BirthDate).NotEmpty();
      RuleFor(d => d.LocationId).NotEmpty();
      RuleFor(d => d.Sex).NotEmpty();


      RuleFor(d => d.Email).EmailAddress();

    }
  }
}
