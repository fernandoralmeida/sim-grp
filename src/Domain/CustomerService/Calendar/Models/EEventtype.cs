using System.ComponentModel.DataAnnotations;

namespace Sim.GRP.Domain.CustomerService.Calendar.Models;

public class EEventtype 
{
    [Key]
    public Guid Id { get; private set; }
}