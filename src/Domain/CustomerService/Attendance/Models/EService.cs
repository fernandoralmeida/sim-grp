using System.ComponentModel.DataAnnotations;
using Sim.GRP.Domain.CustomerService.Owner.Models;

namespace Sim.GRP.Domain.CustomerService.Attendance.Models;

public class EService
{   
    [Key]
    public Guid Id { get; private set; }
    
    [StringLength(255)]
    public string? Name { get; private set; }
    public EOwner? Domain { get; private set; } 
    public bool Active { get; private set; }
}