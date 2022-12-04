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
      RuleFor(a => a.HospitalId).NotEmpty();
      RuleFor(a => a.ProffesionId).NotEmpty();
      RuleFor(a => a.DepartmentId).NotEmpty();
      RuleFor(a => a.PatientId).NotEmpty();
      RuleFor(a => a.DoctorId).NotEmpty();
      RuleFor(a => a.ProffesionId).NotEmpty();
      RuleFor(a => a.AppointmentDate).NotEmpty();
      RuleFor(a => a.AppointmentHour).NotEmpty();
      RuleFor(a => a.DepartmentId).NotEmpty();
      RuleFor(a => a.LocationId).NotEmpty();


    }
  }
}
