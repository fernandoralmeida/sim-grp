using System.ComponentModel.DataAnnotations;
using Sim.GRP.Domain.CustomerService.Attendance.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Models;

public class ECustomer
{
    public enum TGender { Female = 0, Male = 1, NonBinary = 2}

    [Key]
    public Guid Id { get; private set; }
    public bool Active { get; private set; }
    [Required]
    public DateTime? RegistrationDate { get; private set; }
    [Required]
    public DateTime? LastUpdate { get; private set; }

    [StringLength(255)][Required]
    public string? Name { get; private set; }

    [StringLength(255)]
    public string? SocialName { get; private set; }

    [StringLength(11)][Required]
    public string? Document { get; private set; }

    [DataType(DataType.Date)][Required]
    public DateTime? BirthDate { get; private set; }
    public ICollection<EBusiness>? Business { get; private set; }
    public ICollection<ELocation>? Locations { get; private set; }
    public ICollection<EFone>? Fones { get; private set; }
    public ICollection<EEmail>? Emails { get; private set; }
    public ICollection<EAttendance>? Attendances { get; private set; }
    public ICollection<ECompany>? Companies { get; private set; }    

    public ECustomer() { }

    public ECustomer(Guid id, bool active, DateTime? registratiodate, DateTime lastupdate,
        ICollection<ECompany>? companies,
        ICollection<EBusiness>? business,
        ICollection<ELocation>? locations,
        ICollection<EFone>? fones,
        ICollection<EEmail>? emails)
    {
        Id = id;
        Active = active;
        RegistrationDate = registratiodate;
        LastUpdate = lastupdate;
        Companies = companies;
        Business = business;
        Locations = locations;
        Fones = fones;
        Emails = emails;
    }

    
}