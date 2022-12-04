using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;
using TAO.HAS.Entities.DTOs;
using TAO_Core.DataAccess;

namespace TAO.HAS.DataAccess.Abstract
{
  public interface IAppointmentDal: IEntityRepository<Appointment>
  {
    public List<AppointmentDetailDto> GetAppointmentDetails();
    public List<AppointmentDetailDto> GetAppointmentDetailByDoctor(int doctorId);
    public List<AppointmentDetailDto> GetAppointmentDetailByPatient(int doctorId);
    public List<AppointmentDetailDto> GetAppointmentDetailByDate(DateTime date);


  }
}
