using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
using TAO.HAS.Entities.DTOs;
using TAO_Core.DataAccess.EntityFramework;
using System.Linq;

namespace TAO.HAS.DataAccess.Concrete.EntityFramework
{
  public class EfAppointmentDal : EfEntityRepositoryBase<Appointment, HospitalAppointmentSystemContext>, IAppointmentDal
  {
    public List<AppointmentDetailDto> GetAppointmentDetailByDate(DateTime date)
    {
      using (var context = new HospitalAppointmentSystemContext())
      {
        var result = from appointment in context.Appointments
                     join doctor in context.Doctors on appointment.DoctorId equals doctor.Id
                     join department in context.Departments on appointment.DepartmentId equals department.Id
                     join patient in context.Patients on appointment.PatientId equals patient.Id
                     join proffesion in context.Proffesions on appointment.ProffesionId equals proffesion.Id
                     join hospital in context.Hospitals on appointment.HospitalId equals hospital.Id
                     join location in context.Locations on appointment.LocationId equals location.Id
                     where appointment.AppointmentDate == date
                     select new AppointmentDetailDto
                     {
                       Id = appointment.Id,
                       DoctorId = doctor.Id,
                       DoctorFirstName = doctor.FirstName,
                       DoctorLastName = doctor.LastName,
                       PatientId = patient.Id,
                       PatientTCNK = patient.TCNK,
                       PatientFirstName = patient.FirstName,
                       PatientLastName = patient.LastName,
                       PatientEmail = patient.Email,
                       PatientPhoneNumber = patient.PhoneNumber,
                       HospitalId = hospital.Id,
                       HospitalName = hospital.HospitalName,
                       LocationId = location.Id,
                       Country = location.Country,
                       City = location.City,
                       Address = location.Description,
                       DepartmentId = department.Id,
                       Department = department.Description,
                       ProffesionId = proffesion.Id,
                       Proffesion = proffesion.Description,
                       AppointmentId = appointment.Id,
                       AppointmentDate = appointment.AppointmentDate,
                       AppointmentHour = appointment.AppointmentHour


                     };
        return result.ToList();
      }
    }

    public List<AppointmentDetailDto> GetAppointmentDetailByDoctor(int doctorId)
    {
      using (var context = new HospitalAppointmentSystemContext())
      {
        var result = from appointment in context.Appointments
                     join doctor in context.Doctors on appointment.DoctorId equals doctor.Id
                     join department in context.Departments on appointment.DepartmentId equals department.Id
                     join patient in context.Patients on appointment.PatientId equals patient.Id
                     join proffesion in context.Proffesions on appointment.ProffesionId equals proffesion.Id
                     join hospital in context.Hospitals on appointment.HospitalId equals hospital.Id
                     join location in context.Locations on appointment.LocationId equals location.Id
                     where appointment.DoctorId == doctorId
                     select new AppointmentDetailDto
                     {
                       Id = appointment.Id,
                       DoctorId = doctor.Id,
                       DoctorFirstName = doctor.FirstName,
                       DoctorLastName = doctor.LastName,
                       PatientId = patient.Id,
                       PatientTCNK = patient.TCNK,
                       PatientFirstName = patient.FirstName,
                       PatientLastName = patient.LastName,
                       PatientEmail = patient.Email,
                       PatientPhoneNumber = patient.PhoneNumber,
                       HospitalId = hospital.Id,
                       HospitalName = hospital.HospitalName,
                       LocationId = location.Id,
                       Country = location.Country,
                       City = location.City,
                       Address = location.Description,
                       DepartmentId = department.Id,
                       Department = department.Description,
                       ProffesionId = proffesion.Id,
                       Proffesion = proffesion.Description,
                       AppointmentId = appointment.Id,
                       AppointmentDate = appointment.AppointmentDate,
                       AppointmentHour = appointment.AppointmentHour


                     };
        return result.ToList();
      }
    }

    public List<AppointmentDetailDto> GetAppointmentDetailByPatient(int patientId)
    {
      using (var context = new HospitalAppointmentSystemContext())
      {
        var result = from appointment in context.Appointments
                     join doctor in context.Doctors on appointment.DoctorId equals doctor.Id
                     join department in context.Departments on appointment.DepartmentId equals department.Id
                     join patient in context.Patients on appointment.PatientId equals patient.Id
                     join proffesion in context.Proffesions on appointment.ProffesionId equals proffesion.Id
                     join hospital in context.Hospitals on appointment.HospitalId equals hospital.Id
                     join location in context.Locations on appointment.LocationId equals location.Id
                     where appointment.PatientId == patientId
                     select new AppointmentDetailDto
                     {
                       Id = appointment.Id,
                       DoctorId = doctor.Id,
                       DoctorFirstName = doctor.FirstName,
                       DoctorLastName = doctor.LastName,
                       PatientId = patient.Id,
                       PatientTCNK = patient.TCNK,
                       PatientFirstName = patient.FirstName,
                       PatientLastName = patient.LastName,
                       PatientEmail = patient.Email,
                       PatientPhoneNumber = patient.PhoneNumber,
                       HospitalId = hospital.Id,
                       HospitalName = hospital.HospitalName,
                       LocationId = location.Id,
                       Country = location.Country,
                       City = location.City,
                       Address = location.Description,
                       DepartmentId = department.Id,
                       Department = department.Description,
                       ProffesionId = proffesion.Id,
                       Proffesion = proffesion.Description,
                       AppointmentId = appointment.Id,
                       AppointmentDate = appointment.AppointmentDate,
                       AppointmentHour = appointment.AppointmentHour


                     };
        return result.ToList();
      }
    }

    public List<AppointmentDetailDto> GetAppointmentDetails()
    {
      using (var context = new HospitalAppointmentSystemContext())
      {
        var result = from appointment in context.Appointments
                     join doctor in context.Doctors on appointment.DoctorId equals doctor.Id
                     join department in context.Departments on appointment.DepartmentId equals department.Id
                     join patient in context.Patients on appointment.PatientId equals patient.Id
                     join proffesion in context.Proffesions on appointment.ProffesionId equals proffesion.Id
                     join hospital in context.Hospitals on appointment.HospitalId equals hospital.Id
                     join location in context.Locations on appointment.LocationId equals location.Id
                     select new AppointmentDetailDto
                     {
                       Id = appointment.Id,
                       DoctorId = doctor.Id,
                       DoctorFirstName = doctor.FirstName,
                       DoctorLastName = doctor.LastName,
                       PatientId = patient.Id,
                       PatientTCNK = patient.TCNK,
                       PatientFirstName = patient.FirstName,
                       PatientLastName = patient.LastName,
                       PatientEmail = patient.Email,
                       PatientPhoneNumber = patient.PhoneNumber,
                       HospitalId = hospital.Id,
                       HospitalName = hospital.HospitalName,
                       LocationId = location.Id,
                       Country = location.Country,
                       City = location.City,
                       Address = location.Description,
                       DepartmentId = department.Id,
                       Department = department.Description,
                       ProffesionId = proffesion.Id,
                       Proffesion = proffesion.Description,
                       AppointmentId = appointment.Id,
                       AppointmentDate = appointment.AppointmentDate,
                       AppointmentHour = appointment.AppointmentHour


                     };
        return result.ToList();



      }
    }
  }
}
