using System.ComponentModel.DataAnnotations;

namespace Sim.GRP.Domain.CustomerService.Access.Models;

public class EAccess
{
    public enum TAccess { Attendance = 0, Calendar = 1, Customer = 2, Owner = 3, Partner = 4, Logs = 5 }

    [Key]
    public Guid Id { get; private set; }
    public Guid UserID { get; private set; }
    public bool Active { get; private set; }
    public ICollection<TAccess>? Access { get; private set; }

    public EAccess() { }

    public EAccess(Guid id, Guid userid, bool active, ICollection<TAccess> access)
    {
        Id = id;
        UserID = userid;
        Active = active;
        Access = access;
    }
}