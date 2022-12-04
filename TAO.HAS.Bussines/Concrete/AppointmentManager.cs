using System;
using System.Collections.Generic;
using System.Text;
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
  public class AppointmentManager : IAppointmentService
  {
    IAppointmentDal _appointmentDal;
    public AppointmentManager(IAppointmentDal appointmentDal)
    {
      _appointmentDal = appointmentDal;
    }

    public IResult Add(Appointment appointment)
    {
      var result = BusinessRules.Run(CheckIfAppointmentAvailable(appointment.DoctorId,appointment.AppointmentDate,appointment.AppointmentHour),
                                     CheckIfDoctorAppointmentLimit(appointment.DoctorId,appointment.AppointmentDate));
      if(result != null)
      {
        return result;
      }
      _appointmentDal.Add(appointment);
      return new SuccessResult(Messages.AppointmentCreated);
    }

    public IResult Delete(Appointment appointment)
    {
      _appointmentDal.Delete(appointment);
      return new SuccessResult(Messages.AppointmentCanceled);
    }

    public IDataResult<List<Appointment>> GetAll()
    {
      return new SuccessDataResult<List<Appointment>>(_appointmentDal.GetAll(),Messages.AppointmentListed);
    }

    public IDataResult<List<Appointment>> GetByDate(DateTime date)
    {
      return new SuccessDataResult<List<Appointment>>(_appointmentDal.GetAll(a=>a.AppointmentDate == date),Messages.AppointmentListedByDate);
    }

    public IDataResult<List<Appointment>> GetByDoctorId(int doctorId)
    {
      return new SuccessDataResult<List<Appointment>>(_appointmentDal.GetAll(a => a.DoctorId == doctorId), Messages.AppointmentListedByDoctor);
    }

    public IDataResult<List<Appointment>> GetByPatientId(int patientId)
    {
      return new SuccessDataResult<List<Appointment>>(_appointmentDal.GetAll(a => a.PatientId == patientId), Messages.AppointmentListedByPatient);
    }

    public IResult Update(Appointment appointment)
    {
      _appointmentDal.Update(appointment);
      return new SuccessResult(Messages.AppointmentUpdated);
    }
    #region Business Rules 
    private IResult CheckIfAppointmentAvailable(int doctorId, DateTime appointmentDate, DateTime appointmentHour)
    {
      var result = _appointmentDal.GetAll(a=>a.DoctorId == doctorId && a.AppointmentDate == appointmentDate && a.AppointmentHour == appointmentHour).Count;
      if(result > 0)
      {
        return new ErrorResult(Messages.AppointmentIsNotAvailable);
      }
      return new SuccessResult();
    }
    private IResult CheckIfDoctorAppointmentLimit(int doctorId,DateTime appointmentDate)
    {
      var result = _appointmentDal.GetAll(a => a.DoctorId == doctorId && a.AppointmentDate == appointmentDate).Count;
      if(result > 75)
      {
        return new ErrorResult(Messages.DoctorDailyLimitExceded);
      }
      return new SuccessResult();
    }
    #endregion
  }
}
