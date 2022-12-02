using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.Entities.Concrete;
using TAO.HAS.Entities.DTOs;
using TAO_Core.DataAccess.EntityFramework;
using System.Linq;
using log4net.Core;

namespace TAO.HAS.DataAccess.Concrete.EntityFramework
{
  public class EfHospitalDal : EfEntityRepositoryBase<Hospital, HospitalAppointmentSystemContext>, IHospitalDal
  {
    public List<HospitalDetailDto> GetHospitalDetails()
    {
      using (var context = new HospitalAppointmentSystemContext())
      {
        var result = from hospital in context.Hospitals
                     join location in context.Locations on hospital.LocationId equals location.Id
                     select new HospitalDetailDto
                     {
                       HospitalName = hospital.HospitalName,
                       Country = location.Country,
                       City = location.City,
                       Address = location.Description,
                       Capacity = hospital.Capacity
                     };

        return result.ToList();
                     
                    
      }
    }
  }
}
