namespace Sim.GRP.Domain.CustomerService.Owner.Models;

public class EOwner
{
    public enum EHierarchy { Central = 0, Department = 1, Sector = 2 }
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public string? Acronym { get; private set; }
    public EHierarchy? Hierachy { get; private set; }
    public Guid? Domain { get; private set; } //
    public bool Active { get; set; }
}