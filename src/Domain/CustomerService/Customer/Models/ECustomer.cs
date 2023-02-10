using System.ComponentModel.DataAnnotations;
using Sim.GRP.Domain.CustomerService.Attendance.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Models;

public class ECustomer
{

    [Key]
    public Guid Id { get; private set; }
    public bool Active { get; private set; }
    public DateTime? RegistrationDate { get; private set; }
    public DateTime? LastUpdate { get; private set; }

    [StringLength(255)]
    public string? Name { get; private set; }

    [StringLength(14)]
    public string? Document { get; private set; }
    public ICollection<EProfile>? Profile { get; private set; }
    public ICollection<EBusiness>? Business { get; private set; }
    public ICollection<ELocation>? Locations { get; private set; }
    public ICollection<EFone>? Fones { get; private set; }
    public ICollection<EEmail>? Emails { get; private set; }
    public Guid? CustomerLink { get; private set; }
    public ICollection<EAttendance>? Attendances { get; private set; }
    

    public ECustomer() { }

    public ECustomer(Guid id, bool active, DateTime? registratiodate, DateTime lastupdate,
        ICollection<EProfile>? profile,
        ICollection<EBusiness>? business,
        ICollection<ELocation>? locations,
        ICollection<EFone>? fones,
        ICollection<EEmail>? emails)
    {
        Id = id;
        Active = active;
        RegistrationDate = registratiodate;
        LastUpdate = lastupdate;
        Profile = profile;
        Business = business;
        Locations = locations;
        Fones = fones;
        Emails = emails;
    }
}