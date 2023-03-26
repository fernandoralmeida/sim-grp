using System.ComponentModel.DataAnnotations;

namespace Sim.GRP.Domain.CustomerService.Calendar.Models;

public class EWeek
{
    [Key]
    public Guid Id { get; private set; }
    [Required]
    [StringLength(255)]
    public string? Key { get; private set; }
    [Required]
    [StringLength(255)]
    public string? Value { get; private set; }
    public EWeek(){}
    public EWeek(Guid id, string key, string value){
        Id= id;
        Key = key;
        Value = value;
    }
}