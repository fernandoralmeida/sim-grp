using System.ComponentModel.DataAnnotations;

namespace Sim.GRP.Domain.CustomerService.Customer.Models;

public class EFone
{
    public enum TFone { Personal = 0, Business = 1, Corporate = 2, Work = 3 }

    [Key]
    public Guid Id { get; private set; }

    [StringLength(255)]
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