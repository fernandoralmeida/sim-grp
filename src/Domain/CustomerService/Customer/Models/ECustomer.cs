using System.ComponentModel.DataAnnotations;
using Sim.GRP.Domain.CustomerService.Attendance.Models;
using Sim.GRP.Domain.CustomerService.Customer.Helpers;

namespace Sim.GRP.Domain.CustomerService.Customer.Models;

public class ECustomer
{
    public enum TGender { Female = 0, Male = 1, NonBinary = 2 }

    [Key]
    public Guid Id { get; private set; }
    [StringLength(14)]
    [Required]
    public string? Document { get; private set; }
    [DataType(DataType.Date)]
    [Required]
    public DateTime? BirthDate { get; private set; }
    [Required]
    public DateTime? RegistrationDate { get; private set; }
    [Required]
    public DateTime? LastUpdate { get; private set; }
    public ICollection<EAdditional>? Additionals { get; private set; }
    public ICollection<EBusiness>? Business { get; private set; }
    public ICollection<ELocation>? Locations { get; private set; }
    public ICollection<EFone>? Fones { get; private set; }
    public ICollection<EEmail>? Emails { get; private set; }
    public ICollection<EAttendance>? Attendances { get; private set; }
    public ICollection<EBonds>? Bonds { get; private set; }

    public ECustomer() { }

    public ECustomer(Guid id, string document,
                    DateTime birthdate, DateTime registrationdate,
                    DateTime lastupdate, ICollection<EBusiness> businesses,
                    ICollection<ELocation> location, ICollection<EFone> fones,
                    ICollection<EEmail> emails, ICollection<EAttendance> attendances,
                    ICollection<EBonds> bonds, ICollection<EAdditional> additionals)
    {
        Id = id;
        Document = document;
        BirthDate = birthdate;
        RegistrationDate = registrationdate;
        LastUpdate = lastupdate;
        Additionals = additionals;
        Business = businesses;
        Locations = location;
        Fones = fones;
        Emails = emails;
        Attendances = attendances;
        Bonds = bonds;
    }

    public (bool status, string message) Validate(ECustomer obj)
    {
        if (obj.Document!.Length == 11)
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
        else
        {
            if (Extensions.ValidateDocument(obj.Document!))
            {
                if (Convert.ToDateTime(obj.BirthDate) < new DateTime(1000, 1, 1) &&
                    Convert.ToDateTime(obj.BirthDate) > DateTime.Now)
                    return (true, "ok");
                else
                    return (false, "invalid date");
            }
            else
                return (false, "invalid document");
        }

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

    public string? Sectors(ECustomer obj)
    {
        var _list = new List<string>();
        var _group = new List<string>();

        foreach (var items in obj.Business!)
        {
            string[] _arr = items.Code!.Split('.');
            int cnae = Convert.ToInt32(_arr[0]);            

            if (cnae >= 1 && cnae <= 3)                
                _list.Add(items.Primary ? "(P) Agronegócio" : "Agronegócio");

            else if (cnae >= 05 & cnae <= 09 || cnae >= 10 && cnae <= 33)
                _list.Add(items.Primary ? "(P) Indústria" : "Indústria");

            else if (cnae >= 41 & cnae <= 43)
                _list.Add(items.Primary ? "(P) Construção Civil" : "Construção Civil");

            else if (cnae >= 45 && cnae <= 47)
                _list.Add(items.Primary ? "(P) Comércio" : "Comércio");

            else if ((cnae >= 35 && cnae <= 39)
                    || (cnae >= 49 && cnae <= 53)
                    || (cnae >= 55 && cnae <= 56)
                    || (cnae >= 58 && cnae <= 63)
                    || (cnae >= 64 && cnae <= 66)
                    || (cnae >= 68 && cnae <= 75)
                    || (cnae >= 77 && cnae <= 82)
                    || (cnae >= 85 && cnae <= 88)
                    || (cnae >= 90 && cnae <= 93)
                    || (cnae >= 94 && cnae <= 97)
                    || (cnae == 99))
                _list.Add(items.Primary ? "(P) Serviços" : "Serviços");
        }

        foreach (var items in _list.GroupBy(s => s))
            _group.Add(items.Key);

        return string.Empty;
    }
}