namespace Sim.GRP.Domain.CustomerService.Customers.Models;

public class EFone
{
    public enum TFone { Personal = 0, Business = 1, Corporate = 2, Work = 3 }
    public Guid Id { get; private set; }
    public string? Number { get; internal set; }
    public TFone Description { get; internal set; }
    public EFone() { }
    public EFone(Guid id,
        string number, TFone descp)
    {
        Id = id;
        Number = number;
        Description = descp;
    }
}