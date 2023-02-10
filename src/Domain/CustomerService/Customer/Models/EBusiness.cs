using System.ComponentModel.DataAnnotations;

namespace Sim.GRP.Domain.CustomerService.Customer.Models;

public class EBusiness {

    [Key]
    public Guid Id { get; private set; }

    [StringLength(255)]
    public string? Code { get; private set; }

    [StringLength(255)]
    public string? Description { get; private set; }
    
    public bool Primary { get; private set; } 
}