using Microsoft.EntityFrameworkCore;
using Sim.GRP.Domain.CustomerService.Access.Models;
using Sim.GRP.Domain.CustomerService.Calendar.Models;
using Sim.GRP.Domain.CustomerService.Calls.Models;
using Sim.GRP.Domain.CustomerService.Customers.Models;
using Sim.GRP.Domain.CustomerService.Owner.Models;
using Sim.GRP.Domain.CustomerService.Partner.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Context;

public class CustomerServiceContext : DbContext
{
    public CustomerServiceContext() {}

    public CustomerServiceContext(DbContextOptions<CustomerServiceContext> options)
        :base(options) { }

    public DbSet<EAccess>? Access { get; set; }
    public DbSet<EEnrollment>? Enrollment { get; set; }
    public DbSet<EPlanner>? Planner { get; set; }
    public DbSet<ESchedule>? Schedule { get; set; }
    public DbSet<EWeek>? Week { get; set; }
    public DbSet<ECalls>? Call { get; set; }
    public DbSet<EChannel>? Channel { get; set; }
    public DbSet<EService>? Service { get; set; }
    public DbSet<ECustomer>? Customer { get; set; }
    public DbSet<EBusiness>? CustomerBusinesses { get; set; }
    public DbSet<EEmail>? CustomerEmail { get; set; }
    public DbSet<EFone>? CustomerFone { get; set; }
    public DbSet<ELocation>? CustomerLocation { get; set; }
    public DbSet<EProfile>? CustomerProfile { get; set; }
    public DbSet<EOwner>? Owner { get; set; }
    public DbSet<EPartner>? Partner { get; set; }

    public static string? _connectionstring = Environment.GetEnvironmentVariable("connection_sqlserver");

}