
namespace Sim.GRP.Domain.CustomerService.Registers.Models;
public class EExceptions
{
    public Guid Id { get; private set; }
    public string? Exception { get; private set; }
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