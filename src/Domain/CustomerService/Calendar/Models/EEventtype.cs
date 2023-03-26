using System.ComponentModel.DataAnnotations;
using Sim.GRP.Domain.CustomerService.Owner.Models;

namespace Sim.GRP.Domain.CustomerService.Calendar.Models;

public class EEventtype
{
    [Key]
    public Guid Id { get; private set; }
    [Required]
    [StringLength(255)]
    public string? Name { get; private set; }
    public EOwner? Domain { get; private set; }
    public bool Active { get; private set; }
    public EEventtype() { }
    public EEventtype(Guid id, string name,
        EOwner domain, bool active)
    {
        Id = id;
        Name = name;
        Domain = domain;
        Active = active;
    }

}