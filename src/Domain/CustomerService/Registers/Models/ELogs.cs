using System.ComponentModel.DataAnnotations;

namespace Sim.GRP.Domain.CustomerService.Registers.Models;
public class ELogs
{
    [Key]
    public Guid Id { get; private set; }
    [Required][StringLength(255)]
    public string? Activity { get; private set; }
    public DateTime RegistrationDate { get; private set; }
    public Guid UserID { get; private set; }
    public ELogs() { }
    public ELogs(Guid id, string activity,
        DateTime registrationdate, Guid userid)
    {
        Id = id;
        Activity = activity;
        RegistrationDate = registrationdate;
        UserID = userid;
    }


}