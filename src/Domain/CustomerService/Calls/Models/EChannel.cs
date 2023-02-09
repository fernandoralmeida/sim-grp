using Sim.GRP.Domain.CustomerService.Owner.Models;

namespace Sim.GRP.Domain.CustomerService.Calls.Models;

public class EChannel
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public EOwner? Domain { get; private set; }
    public bool Active { get; private set; }
}