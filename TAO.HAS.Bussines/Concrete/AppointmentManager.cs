using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Business.Constans;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
using TAO.HAS.Entities.DTOs;
using TAO_Core.Utilities.Business;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results.Concrete;

namespace TAO.HAS.Business.Concrete
{
  public class AppointmentManager : IAppointmentService
  {
    IAppointmentDal _appointmentDal;
    IHospitalService _hospitalService;
    public AppointmentManager(IAppointmentDal appointmentDal, IHospitalService hospitalService)
    {
      _appointmentDal = appointmentDal;
      _hospitalService = hospitalService;
    }

    public IResult Add(Appointment appointment)
    {
      var result = BusinessRules.Run(CheckIfTimeIsMaintanceTime(),
                                     CheckIfAppointmentHourAvailable(appointment.AppointmentHour),
                                     CheckIfAppointmentAvailable(appointment.DoctorId, appointment.AppointmentDate, appointment.AppointmentHour),
                                     CheckIfDoctorAppointmentLimitExceded(appointment.DoctorId, appointment.AppointmentDate),
                                     CheckIfPatientAppointmentLimitExceded(appointment.PatientId, appointment.AppointmentDate));
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

    public IDataResult<List<AppointmentDetailDto>> GetAppointmentDetails()
    {
      return new SuccessDataResult<List<AppointmentDetailDto>>(_appointmentDal.GetAppointmentDetails(), Messages.AppointmentDetailsListed);
    }

    public IDataResult<List<AppointmentDetailDto>> GetAppointmentDetailsByDoctor(int doctorId)
    {
      return new SuccessDataResult<List<AppointmentDetailDto>>(_appointmentDal.GetAppointmentDetailByDoctor(doctorId));

    }

    public IDataResult<List<AppointmentDetailDto>> GetAppointmentDetailsByPatient(int patientId)
    {
      return new SuccessDataResult<List<AppointmentDetailDto>>(_appointmentDal.GetAppointmentDetailByPatient(patientId));

    }

    public IDataResult<List<AppointmentDetailDto>> GetAppointmentDetailsByDate(DateTime date)
    {
      return new SuccessDataResult<List<AppointmentDetailDto>>(_appointmentDal.GetAppointmentDetailByDate(date));

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
    private IResult CheckIfDoctorAppointmentLimitExceded(int doctorId,DateTime appointmentDate)
    {
      var result = _appointmentDal.GetAll(a => a.DoctorId == doctorId && a.AppointmentDate == appointmentDate).Count;
      if(result > 75)
      {
        return new ErrorResult(Messages.DoctorDailyLimitExceded);
      }
      return new SuccessResult();
    }
    private IResult CheckIfPatientAppointmentLimitExceded(int patientId,DateTime appointmentDate)
    {
      var result = _appointmentDal.GetAll(a => a.PatientId == patientId && a.AppointmentDate == appointmentDate).Count;
      if(result > 20)
      {
        return new ErrorResult(Messages.PatientDailyLimitExceded);
      }
      return new SuccessResult();
    }
    /*
    private IResult CheckIfHospitalLimitExceded(int hospitalId)
    {
      var result = _appointmentDal.GetAll(a=>a.HospitalId == hospitalId).Count;
      var capacity = _hospitalService.GetAll();
      if( result > capacity.Data.Count)
      {
        return new ErrorResult(Messages.HospitalCapacityExceded);
      }
      return new SuccessResult();
    }*/
    private IResult CheckIfAppointmentHourAvailable(DateTime appointmentHour)
    {
      var result = _appointmentDal.GetAll(a=>a.AppointmentHour == appointmentHour);
      if(Convert.ToInt32(appointmentHour) >= 17)
      {
        return new ErrorResult(Messages.OutOfHours);
      }
      return new SuccessResult();
    }
    private IResult CheckIfTimeIsMaintanceTime()
    {
      if(Convert.ToInt32(DateTime.Now.Hour) == 22)
      {
        return new ErrorResult(Messages.SystemOnMaintance);
      }
      return new SuccessResult();
    }

  
    #endregion
  }
}
