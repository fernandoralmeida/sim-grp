using System.ComponentModel.DataAnnotations;

namespace Sim.GRP.Domain.CustomerService.Calendar.Models;
public class EPlanner
{
    [Key]
    public Guid Id { get; private set; }
    public DateTime? InitialDate { get; private set; }
    public DateTime? FinalDate { get; private set; }
    public Guid? UserID { get; private set; }
    public ICollection<EWeek>? Weeks { get; private set; }
    public EPlanner() { }
    public EPlanner(Guid id, DateTime initialdate,
        DateTime finaldate, Guid userid, ICollection<EWeek> weeks)
    {
        Id = id;
        InitialDate = initialdate;
        FinalDate = finaldate;
        UserID = userid;
        Weeks = weeks;
    }
}