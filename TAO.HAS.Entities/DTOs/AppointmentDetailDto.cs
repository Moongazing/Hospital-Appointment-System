using System;
using System.Collections.Generic;
using System.Text;
using TAO_Core;

namespace TAO.HAS.Entities.DTOs
{
  public class AppointmentDetailDto : IDto
  {
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public string DoctorFirstName { get; set; }
    public string DoctorLastName { get; set; }
    public int PatientId { get; set; }
    public string PatientTCNK { get; set; }
    public string PatientFirstName { get; set; }
    public string PatientLastName { get; set; }
    public string PatientPhoneNumber { get; set; }
    public string PatientEmail { get; set; }
    public int LocationId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string  Address { get; set; }
    public int HospitalId { get; set; }
    public string HospitalName { get; set; }
    public int DepartmentId { get; set; }
    public string Department { get; set; }
    public int AppointmentId { get; set; }
    public int ProffesionId { get; set; }
    public string Proffesion { get; set; }
    public DateTime AppointmentDate { get; set; }
    public DateTime AppointmentHour { get; set; }
  }
}
