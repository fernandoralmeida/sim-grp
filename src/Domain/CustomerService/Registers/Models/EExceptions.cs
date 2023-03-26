
using System.ComponentModel.DataAnnotations;

namespace Sim.GRP.Domain.CustomerService.Registers.Models;
public class EExceptions
{
    [Key]
    public Guid Id { get; private set; }
    [StringLength(255)][Required]
    public string? Exception { get; private set; }
    [StringLength(255)][Required]
    public string? Activity { get; private set; }
    public DateTime RegistrationDate { get; private set; }
    public Guid UserID { get; private set; }
    public EExceptions() { }
    public EExceptions(Guid id, string exception, string activity,
        DateTime registrationdate, Guid userid)
    {
        Id = id;
        Exception = exception;
        Activity = activity;
        RegistrationDate = registrationdate;
        UserID = userid;
    }
}