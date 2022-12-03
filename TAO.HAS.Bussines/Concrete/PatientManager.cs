using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Business.Constans;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
using TAO_Core.Utilities.Business;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;

namespace TAO.HAS.Business.Concrete
{
  public class PatientManager : IPatientService
  {
    IPatientDal _patientDal;
    public PatientManager(IPatientDal patientDal)
    {
      _patientDal = patientDal;
    }

    public IResult Add(Patient patient)
    {
      var result = BusinessRules.Run(CheckIfTCKNRight(patient.TCNK),
                                     CheckIfPatientExists(patient.TCNK),
                                     CheckIfPatientAge(patient.BirthDate.Year)
                                     );
      if (result != null)
      {
        return result;
      }
      _patientDal.Add(patient);
      return new SuccessResult(Messages.PatientAdded);
    }

    public IResult Delete(Patient patient)
    {
      _patientDal.Delete(patient);
      return new SuccessResult(Messages.PatientDeleted);
    }

    public IDataResult<List<Patient>> GetAll()
    {
      return new SuccessDataResult<List<Patient>>(_patientDal.GetAll(), Messages.PatientListed);
    }

    public IDataResult<List<Patient>> GetByBirthYear(DateTime minYear, DateTime maxYear)
    {
      return new SuccessDataResult<List<Patient>>(_patientDal.GetAll(p => p.BirthDate.Year > Convert.ToInt32(minYear) && p.BirthDate.Year < Convert.ToInt32(maxYear)), Messages.PatientListed);
    }

    public IDataResult<List<Patient>> GetByBloodType(string bloodType)
    {
      return new SuccessDataResult<List<Patient>>(_patientDal.GetAll(p => p.BloodType == bloodType), Messages.PatientListed);
    }

    public IResult Update(Patient patient)
    {
      _patientDal.Update(patient);
      return new SuccessResult(Messages.PatientUpdated);
    }

    #region Bussiness Rules
    private IResult CheckIfPatientExists(string nationalIdentity)
    {
      var result = _patientDal.GetAll(p => p.TCNK == nationalIdentity).Count;
      if (result > 0)
      {
        return new ErrorResult(Messages.PatientAlreadyExists);
      }
      return new SuccessResult();
    }
    private IResult CheckIfPatientAge(int year)
    {
      var currentYear = DateTime.Now.Year;
      var patientBirthYear = _patientDal.GetAll(p => p.BirthDate.Year == year);
      int patientAge = currentYear - Convert.ToInt32(patientBirthYear);

      if (patientAge < 18)
      {
        return new ErrorResult(Messages.PatientShouldBeToAppearChildDoctor);
      }
      return new SuccessResult();
    }
    private IResult CheckIfTCKNRight(string nationalIdentity)
    {
      /*This rule for the Turkey Identity Algorithm*/

      int oddNumbersTotal = 0;
      int evenNumbersTotal = 0;
      int total10 = 0;

      if (nationalIdentity.Length != 11 || nationalIdentity.Substring(0 , 1) == "0" || nationalIdentity.All(char.IsDigit) == false)
      {
        return new ErrorResult(Messages.CheckTheTCKN);
      }
      for (int i = 0; i < nationalIdentity.Length; i++)
      {
        Convert.ToInt32(nationalIdentity[i].ToString());
        if (nationalIdentity[i] != 10)
        {
          total10 += nationalIdentity[i];
        }
        if (nationalIdentity[i] % 2 != 0)
        {
          oddNumbersTotal += nationalIdentity[i];
        }
        else
        {
          evenNumbersTotal += nationalIdentity[i];
        }
      }

      if ((7 * oddNumbersTotal - evenNumbersTotal) % 10 != nationalIdentity[10])
      {
        return new ErrorResult(Messages.CheckTheTCKN);
      }
      if (total10 % 10 != nationalIdentity[10])
      {
        return new ErrorResult(Messages.CheckTheTCKN);
      }

      return new SuccessResult();
    }
    #endregion
  }
}
