using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using TAO.HAS.Business.Abstract;
using TAO.HAS.Business.Concrete;
using TAO.HAS.DataAccess.Abstract;
using TAO.HAS.DataAccess.Concrete.EntityFramework;

using TAO_Core.Utilities.Interceptors;
using TAO_Core.Utilities.Security.JWT;

namespace TAO.HAS.Business.DependencyResolvers.Autofac
{
  public class AutofacBusinessModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<DoctorManager>().As<IDoctorService>().SingleInstance();
      builder.RegisterType<EfDoctorDal>().As<IDoctorDal>().SingleInstance();
      
      builder.RegisterType<DepartmentManager>().As<IDepartmentService>().SingleInstance();
      builder.RegisterType<EfDepartmentDal>().As<IDepartmentDal>().SingleInstance();

      builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
      builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

      builder.RegisterType<AuthManager>().As<IAuthService>();
      builder.RegisterType<JwtHelper>().As<ITokenHelper>();

      builder.RegisterType<AppointmentManager>().As<IAppointmentService>();
      builder.RegisterType<EfAppointmentDal>().As<IAppointmentDal>();

      builder.RegisterType<ProffesionManager>().As<IProffesionService>();
      builder.RegisterType<EfProffesionDal>().As<IProffesionDal>();

      builder.RegisterType<HospitalManager>().As<IHospitalService>();
      builder.RegisterType<EfHospitalDal>().As<IHospitalDal>();

      builder.RegisterType<LocationManager>().As<ILocationService>();
      builder.RegisterType<EfLocationDal>().As<ILocationDal>();

      builder.RegisterType<DoctorManager>().As<IDoctorService>();
      builder.RegisterType<EfDoctorDal>().As<IDoctorDal>();

      builder.RegisterType<PatientManager>().As<IPatientService>();
      builder.RegisterType<EfPatientDal>().As<IPatientDal>();




      /* builder.RegisterType<FileLogger>().As<LoggerServiceBase>().SingleInstance();
       builder.RegisterType<DatabaseLogger>().As<LoggerServiceBase>().SingleInstance();*/


      var assembly = System.Reflection.Assembly.GetExecutingAssembly();
      builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
               .EnableInterfaceInterceptors(new ProxyGenerationOptions()
               {
                 Selector = new AspectInterceptorSelector()
               }).SingleInstance();
    }

  }
}
