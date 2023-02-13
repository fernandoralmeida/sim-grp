using System.ComponentModel.DataAnnotations;

namespace Sim.GRP.Domain.CustomerService.Customer.Models;


public class EEmail
{
    public enum TEmail { Personal = 0, Business = 1, Corporate = 2, Work = 3 }

    [Key]
    public Guid Id { get; private set; }

    [StringLength(255)]
    [Required]
    public string? Address { get; internal set; }
    [Required]
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