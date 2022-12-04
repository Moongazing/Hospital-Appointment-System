using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Business.Abstract;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;

namespace TAO.HAS.Business.Concrete
{
  public class AppointmentManager : IAppointmentService
  {
    IAppointmentDal _appointmentDal;
    public AppointmentManager(IAppointmentDal appointmentDal)
    {
      _appointmentDal = appointmentDal;
    }

    public IResult Add(Appointment appointment)
    {
      throw new NotImplementedException();
    }

    public IResult Delete(Appointment appointment)
    {
      throw new NotImplementedException();
    }

    public IDataResult<List<Appointment>> GetAll()
    {
      throw new NotImplementedException();
    }

    public IDataResult<List<Appointment>> GetByDate(DateTime date)
    {
      throw new NotImplementedException();
    }

    public IDataResult<List<Appointment>> GetByDoctorId(int doctorId)
    {
      throw new NotImplementedException();
    }

    public IDataResult<List<Appointment>> GetByPatientId(int patientId)
    {
      throw new NotImplementedException();
    }

    public IResult Update(Appointment appointment)
    {
      throw new NotImplementedException();
    }
  }
}
