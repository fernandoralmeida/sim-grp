using System.ComponentModel.DataAnnotations;

namespace Sim.GRP.Domain.CustomerService.Access.Models;

public class EAccess
{
    [Key]
    public Guid Id { get; private set; }
    public Guid UserID { get; private set; }
    public DateTime? AccessDate { get; private set; }
    public bool Active { get; private set; }
}