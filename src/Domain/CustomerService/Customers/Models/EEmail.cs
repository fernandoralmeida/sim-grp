namespace Sim.GRP.Domain.CustomerService.Customers.Models;


public class EEmail
{
    public enum TEmail { Personal = 0, Business = 1, Corporate = 2, Work = 3 }
    public Guid Id { get; private set; }
    public string? Address { get; internal set; }
    public TEmail Description { get; internal set; }
    public EEmail() { }
    public EEmail(Guid id,
        string address, TEmail descp)
    {
        Id = id;
        Address = address;
        Description = descp;
    }
}