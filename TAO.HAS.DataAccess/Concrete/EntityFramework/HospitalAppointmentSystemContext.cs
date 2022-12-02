
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using TAO.HAS.Entities.Concrete;
using TAO_Core.Entities.Concrete;

namespace TAO.HAS.DataAccess.Concrete.EntityFramework
{
  public class HospitalAppointmentSystemContext:DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server =(localdb)\MSSQLLocalDB;Database =HospitalAppointmentSystem;Trusted_Connection=true");
    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Proffesion> Proffesions { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }



  }
}
