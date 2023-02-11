using System.ComponentModel.DataAnnotations;

namespace Sim.GRP.Domain.CustomerService.Access.Models;

public class EAccess
{
    [Key]
    public Guid Id { get; private set; }
    public Guid UserID { get; private set; }
    public bool Active { get; private set; }

    public EAccess(){}

    public EAccess(Guid id, Guid userid, bool active)
    {
        Id = id;
        UserID = userid;
        Active = active;
    }
}