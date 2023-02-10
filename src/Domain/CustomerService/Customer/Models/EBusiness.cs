namespace Sim.GRP.Domain.CustomerService.Customer.Models;

public class EBusiness {
    public Guid Id { get; private set; }
    public string? Code { get; private set; }
    public string? Description { get; private set; }
    public bool Primary { get; private set; } 
}