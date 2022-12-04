using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;

namespace TAO.HAS.Business.ValidationRules.FluentValidation
{
  public class AppointmentValidator:AbstractValidator<Appointment>
  {
    public AppointmentValidator()
    {

    }
  }
}
