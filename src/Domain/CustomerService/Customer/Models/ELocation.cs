using System.ComponentModel.DataAnnotations;

namespace Sim.GRP.Domain.CustomerService.Customer.Models;

public class ELocation
{

    [Key]
    public Guid Id { get; private set; }

    [StringLength(8)]
    public string? Zipcode { get; internal set; }

    [StringLength(255)]
    public string? Address { get; internal set; }

    [StringLength(10)]
    public string? Number { get; internal set; }

    [StringLength(255)]
    public string? District { get; internal set; }

    [StringLength(255)]
    public string? City { get; internal set; }

    [StringLength(255)]
    public string? State { get; internal set; }

    [StringLength(255)]
    public string? Country { get; internal set; }
    public ELocation() { }
    public ELocation(Guid id, string zipcode, string address,
        string number, string district,
        string city, string state, string country)
    {
        Id = id;
        Zipcode = zipcode;
        Address = address;
        Number = number;
        District = district;
        City = city;
        State = state;
        Country = country;
    }
}