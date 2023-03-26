using System.ComponentModel.DataAnnotations;

namespace Sim.GRP.Domain.CustomerService.Registers.Models;

public class EProtocols
{
    [Key]
    public Guid Id { get; private set; }
    [Required][StringLength(255)]
    public string? Protocol { get; private set; }
    [Required][StringLength(255)]
    public string? Description { get; private set; }
    public DateTime RegistrationDate { get; private set; }
    public Guid UserID { get; private set; }
    public EProtocols() { }
    public EProtocols(Guid id, string protocol, string description,
        DateTime registrationdate, Guid userid)
    {
        Id = id;
        Protocol = protocol;
        Description = description;
        RegistrationDate = registrationdate;
        UserID = userid;
    }
    internal string New() 
        => $"{DateTime.Now:yyyy}-{DateTime.Now.DayOfYear:000}-{DateTime.Now:HHmmss.ff}";
}