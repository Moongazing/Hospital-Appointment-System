using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Entities.Concrete;
using TAO.HAS.Entities.DTOs;
using TAO_Core.Utilities.Results;
using TAO_Core.Utilities.Results.Abstract;

namespace TAO.HAS.Business.Abstract
{
  public interface IDoctorService
  {
    IResult Add(Doctor doctor);
    IResult Delete(Doctor doctor);
    IResult Update(Doctor doctor);
    IDataResult<List<DoctorDetailDto>> GetDoctorDetails();
    IDataResult<List<Doctor>> GetAll();
    IDataResult<List<Doctor>> GetByDepartment(int departmentId);
    IDataResult<List<Doctor>> GetByProffesion(int proffesionId);



  }
}
