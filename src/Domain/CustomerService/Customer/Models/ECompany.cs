using System.ComponentModel.DataAnnotations;
using Sim.GRP.Domain.CustomerService.Customer.Helpers;

namespace Sim.GRP.Domain.CustomerService.Customer.Models;
public class ECompany
{
    [Key]
    public Guid Id { get; private set; }
    [StringLength(7)]
    public string? Matrix { get; private set; }
    [StringLength(14)]
    [Required]
    public string? Document { get; private set; }
    [Required]
    [StringLength(255)]
    public string? Name { get; private set; }
    [StringLength(255)]
    public string? CommercialName { get; private set; }
    [StringLength(255)]
    public string? Situation { get; private set; }
    [StringLength(255)]
    public string? Port { get; private set; }
    [StringLength(255)]
    public DateTime? FundationDate { get; private set; }
    public DateTime? RegistrationDate { get; private set; }
    public DateTime? LastUpdate { get; private set; }
    public ICollection<EBusiness>? Business { get; private set; }
    public ICollection<ELocation>? Locations { get; private set; }
    public ICollection<EFone>? Fones { get; private set; }
    public ICollection<EEmail>? Emails { get; private set; }

    public (bool status, string message) Validate(ECompany obj)
    {
        if (Extensions.ValidateDocument(obj.Document!))
        {
            if (Convert.ToDateTime(obj.FundationDate) < new DateTime(1000, 1, 1) &&
                Convert.ToDateTime(obj.FundationDate) > DateTime.Now)
                return (true, "ok");
            else
                return (false, "invalid date");
        }
        else
            return (false, "invalid document");
    }
    
    public ICollection<string>? SecondarySectors(ECompany obj)
    {
        var _list = new List<string>();
        var _group = new List<string>();

        foreach (var items in obj.Business!.Where(s => s.Primary == false))
        {
            int cnae = Convert.ToInt32(items.Code!.Split(".", 2));

            if (cnae >= 01 && cnae <= 03)
                _list.Add("Agronegócios");

            else if (cnae >= 05 & cnae <= 09 || cnae >= 10 && cnae <= 33)
                _list.Add("Indústria");

            else if (cnae >= 41 & cnae <= 43)
                _list.Add("Construção Civil");

            else if (cnae >= 45 && cnae <= 47)
                _list.Add("Comércio");

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
                _list.Add("Serviços");
        }

        foreach (var items in _list.GroupBy(s => s))
            _group.Add(items.Key);

        return _group;
    }
    public string? Sectors(ECompany obj)
    {
        foreach (var items in obj.Business!.Where(s => s.Primary == true))
        {
            int cnae = Convert.ToInt32(items.Code!.Split(".", 2));

            if (cnae >= 1 && cnae <= 3)
                return "Agronegócios";

            else if (cnae >= 05 & cnae <= 09 || cnae >= 10 && cnae <= 33)
                return "Indústria";

            else if (cnae >= 41 & cnae <= 43)
                return "Construção Civil";

            else if (cnae >= 45 && cnae <= 47)
                return "Comércio";

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
                return "Serviços";
        }

        return string.Empty;
    }
}