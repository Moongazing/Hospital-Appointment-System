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
  public class EfDoctorDal : EfEntityRepositoryBase<Doctor, HospitalAppointmentSystemContext>, IDoctorDal
  {
    public List<DoctorDetailDto> GetDoctorDetails()
    {
      using (var context = new HospitalAppointmentSystemContext())
      {
        var result = from doctor in context.Doctors
                     join location in context.Locations on doctor.LocationId equals location.Id
                     join department in context.Departments on doctor.DepartmentId equals department.Id
                     join proffesion in context.Proffesions on doctor.ProffesionId equals proffesion.Id
                     join hospital in context.Hospitals on doctor.HospitalId equals hospital.Id
                     select new DoctorDetailDto
                     
                     {
                       Id  = doctor.Id,
                       FirstName = doctor.FirstName,
                       LastName = doctor.LastName,
                       Department = department.Description,
                       Proffesion = proffesion.Description,
                       Location = location.Description,
                       Hospital = hospital.HospitalName,
                       Email = doctor.Email,
                       BirthDate = doctor.BirthDate,
                       Sex = doctor.Sex,
                       Status = doctor.Status,

                     };
        return result.ToList();
        
       

      }
    }
  }
}
