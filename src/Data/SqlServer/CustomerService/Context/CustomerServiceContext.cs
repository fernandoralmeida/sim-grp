using Microsoft.EntityFrameworkCore;
using Sim.GRP.Domain.CustomerService.Access.Models;
using Sim.GRP.Domain.CustomerService.Calendar.Models;
using Sim.GRP.Domain.CustomerService.Attendance.Models;
using Sim.GRP.Domain.CustomerService.Customer.Models;
using Sim.GRP.Domain.CustomerService.Owner.Models;
using Sim.GRP.Domain.CustomerService.Partner.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Context;

public class CustomerServiceContext : DbContext
{
    public CustomerServiceContext() {}

    public CustomerServiceContext(DbContextOptions<CustomerServiceContext> options)
        :base(options) { }

    public DbSet<EAccess>? Access { get; set; }
    public DbSet<EEnrollment>? EventEnrollments { get; set; }
    public DbSet<EPlanner>? EventPlanners { get; set; }
    public DbSet<EEvent>? Events { get; set; }
    public DbSet<EWeek>? EventWeek { get; set; }
    public DbSet<EAttendance>? Attendances { get; set; }
    public DbSet<EChannel>? AttendanceChannels { get; set; }
    public DbSet<EService>? AttendanceServices { get; set; }
    public DbSet<ECustomer>? Customers { get; set; }
    public DbSet<EBonds>? Bonds { get; set; }
    public DbSet<EBusiness>? CustomerBusinesses { get; set; }
    public DbSet<EEmail>? CustomerEmail { get; set; }
    public DbSet<EFone>? CustomerFone { get; set; }
    public DbSet<ELocation>? CustomerLocation { get; set; }
    public DbSet<EAdditional>? CustomerAdditionals { get; set; }
    public DbSet<EOwner>? Owners { get; set; }
    public DbSet<EPartner>? Partners { get; set; }

    public static string? _connectionstring = Environment.GetEnvironmentVariable("connection_sqlserver");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Mapping.AdditionalsMapping());
        modelBuilder.ApplyConfiguration(new Mapping.CustomerMapping());
        modelBuilder.ApplyConfiguration(new Mapping.LocationMapping());

        base.OnModelCreating(modelBuilder);
    }

    

}