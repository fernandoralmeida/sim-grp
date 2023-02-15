using System.ComponentModel.DataAnnotations;
using Sim.GRP.Domain.CustomerService.Attendance.Models;
using Sim.GRP.Domain.CustomerService.Customer.Helpers;

namespace Sim.GRP.Domain.CustomerService.Customer.Models;

public class ECustomer
{
    public enum TGender { Female = 0, Male = 1, NonBinary = 2 }

    [Key]
    public Guid Id { get; private set; }
    [StringLength(255)]
    [Required]
    public string? Name { get; private set; }

    [StringLength(255)]
    public string? SocialName { get; private set; }

    [StringLength(11)]
    [Required]
    public string? Document { get; private set; }

    [DataType(DataType.Date)]
    [Required]
    public DateTime? BirthDate { get; private set; }
    [Required]
    public DateTime? RegistrationDate { get; private set; }
    [Required]
    public DateTime? LastUpdate { get; private set; }
    public ICollection<EBusiness>? Business { get; private set; }
    public ICollection<ELocation>? Locations { get; private set; }
    public ICollection<EFone>? Fones { get; private set; }
    public ICollection<EEmail>? Emails { get; private set; }
    public ICollection<EAttendance>? Attendances { get; private set; }
    public ICollection<ECompany>? Companies { get; private set; }

    public ECustomer() { }

    public ECustomer(Guid id, string name,
                    string socialname, string document,
                    DateTime birthdate, DateTime registrationdate,
                    DateTime lastupdate, ICollection<EBusiness> businesses,
                    ICollection<ELocation> location, ICollection<EFone> fones,
                    ICollection<EEmail> emails, ICollection<EAttendance> attendances,
                    ICollection<ECompany> companies)
    {
        Id = id;
        Name = name;
        SocialName = socialname;
        Document = document;
        BirthDate = birthdate;
        RegistrationDate = registrationdate;
        LastUpdate = lastupdate;
        Business = businesses;
        Locations = location;
        Fones = fones;
        Emails = emails;
        Attendances = attendances;
        Companies = companies;
    }

    public (bool status, string message) Validate(ECustomer obj)
    {
        if (Extensions.Validadte_Document(obj.Document!))
        {
            if (Convert.ToDateTime(obj.BirthDate) > DateTime.Now.AddYears(-16) &&
                Convert.ToDateTime(obj.BirthDate) < DateTime.Now.AddDays(-130))
                return (true, "ok");
            else
                return (false, "invalid date");
        }
        else
            return (false, "invalid document");
    }

    public bool Recurrent(ECustomer obj)
    {
        var _last_att = obj.Attendances!.Where(s => s.EndService > DateTime.Now.AddDays(-60));
        return _last_att.Count() > 0 ? true : false;
    }

    public bool BirthDateDay(ECustomer obj)
        => obj.BirthDate!.Value.Day == DateTime.Now.Day &&
            obj.BirthDate!.Value.Month == DateTime.Now.Month == true ?
            true :
            false;
}