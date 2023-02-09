using Sim.GRP.Domain.CustomerService.Customers.Models;
using Sim.GRP.Domain.CustomerService.Owner.Models;

namespace Sim.GRP.Domain.CustomerService.Calls.Models;

public class ECalls
{
    public enum TStatus { Normal = 0, Active = 1, Closed = 2, Canceled = 3 }
    public Guid Id { get; private set; }    
    public string? Protocol { get; private set; }
    public DateTime StartService { get; private set; }
    public DateTime? EndService { get; private set; }
    public DateTime LastUpdate { get; private set; }
    public TStatus Status { get; private set; }
    public ICollection<ECustomer>? Customers { get; private set; }
    public EOwner? Domain { get; private set; }
    public EChannel? Channel { get; private set; }
    public ICollection<EService>? Services { get; private set; }    
    public string? Description { get; private set; }
    public Guid UserID { get; private set; }

    public bool IsAnonymous(ECalls obj)
        => obj.Customers == null ? true : false;
}

