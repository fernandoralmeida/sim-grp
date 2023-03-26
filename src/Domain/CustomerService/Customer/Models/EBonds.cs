using System.ComponentModel.DataAnnotations;
using Sim.GRP.Domain.CustomerService.Customer.Helpers;

namespace Sim.GRP.Domain.CustomerService.Customer.Models;
public class EBonds
{
    [Key]
    public Guid Id { get; private set; }
    public ECustomer? Customer { get; private set; }
    [StringLength(255)]
    public string? Bond { get; private set; }

}