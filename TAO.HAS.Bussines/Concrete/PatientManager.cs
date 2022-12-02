using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Business.Constans;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
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

    public IDataResult<List<Patient>> GetByAge(int minAge, int maxAge)
    {
      throw new NotImplementedException();
    }

    public IDataResult<List<Patient>> GetByBloodType(string bloodType)
    {
      throw new NotImplementedException();
    }

    public IResult Update(Patient patient)
    {
      throw new NotImplementedException();
    }
  }
}
