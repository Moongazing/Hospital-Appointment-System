using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;
using TAO.HAS.Entities.DTOs;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results;

namespace TAO.HAS.Business.Abstract
{
  public interface IPatientService
  {
    IResult Add(Patient patient);
    IResult Delete(Patient patient);
    IResult Update(Patient patient);
    IDataResult<List<Patient>> GetAll();
    IDataResult<List<Patient>> GetByBloodType(string bloodType);
    IDataResult<List<Patient>> GetByBirthYear(DateTime minYear,DateTime maxYear);
  }
}
