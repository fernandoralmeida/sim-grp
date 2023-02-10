using System.ComponentModel.DataAnnotations;

namespace Sim.GRP.Domain.CustomerService.Calendar.Models;

public class EWeek
{
    [Key]
    public Guid Id { get; private set; }

    [StringLength(255)]
    public string? Key { get; private set; }

    [StringLength(255)]
    public string? Value { get; private set; }
}