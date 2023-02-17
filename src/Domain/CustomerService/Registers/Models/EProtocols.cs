namespace Sim.GRP.Domain.CustomerService.Registers.Models;

public class EProtocols
{
    public Guid Id { get; private set; }
    public string? Protocol { get; private set; }
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
    public string New() 
        => $"{DateTime.Now.Year}-{DateTime.Now.DayOfYear.ToString("000")}-{DateTime.Now.TimeOfDay.TotalDays}";
}