namespace Sim.GRP.Domain.CustomerService.Customers.Models;

public class ELocation {
    public Guid Id { get; private set; }
    public string? Zipcode { get; internal set; }
    public string? Address { get; internal set; }
    public string? Number { get; internal set; }
    public string? District { get; internal set; }
    public string? City { get; internal set; }
    public string? State { get; internal set; }
    public string? Country { get; internal set; }
}