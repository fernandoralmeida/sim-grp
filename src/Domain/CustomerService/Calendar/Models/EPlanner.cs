namespace Sim.GRP.Domain.CustomerService.Calendar.Models;
public class EPlanner
{
    public Guid Id { get; private set; }
    public DateTime? InitialDate { get; private set; }
    public DateTime? FinalDate { get; private set; }
    public Guid? UserID { get; private set; }
    public ICollection<EWeek>? Weeks { get; private set; }
}