using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core.Entities;

namespace TAO.HAS.Entities.Concrete
{
  public class Appointment:IEntity
  {
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public int LocationId { get; set; }
    public int HospitalId { get; set; }
    public int DepartmentId { get; set; } 
    public int AppointmentId { get; set; }
    public int ProffesionId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public DateTime AppointmentHour { get; set; }


  }
}
