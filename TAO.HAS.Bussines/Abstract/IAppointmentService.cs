using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;
using TAO.HAS.Entities.DTOs;
using TAO_Core.Utilities.Results.Abstract;
using TAO_Core.Utilities.Results;

namespace TAO.HAS.Business.Abstract
{
  public interface IAppointmentService
  {
    IResult Add(Appointment appointment);
    IResult Delete(Appointment appointment);
    IResult Update(Appointment appointment);
    IDataResult<List<Appointment>> GetAll();
    IDataResult<List<Appointment>> GetByPatientId(int patientId);
    IDataResult<List<Appointment>> GetByDoctorId(int doctorId);
    IDataResult<List<Appointment>> GetByDate(DateTime date);

    IDataResult<List<AppointmentDetailDto>> GetAppointmentDetails();
    IDataResult<List<AppointmentDetailDto>> GetAppointmentDetailsByDoctor(int doctorId);
    IDataResult<List<AppointmentDetailDto>> GetAppointmentDetailsByPatient(int patientId);
    IDataResult<List<AppointmentDetailDto>> GetAppointmentDetailsByDate(DateTime date);



  }
}
