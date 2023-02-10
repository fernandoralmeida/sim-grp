using System.ComponentModel.DataAnnotations;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Calendar.Models;

public class EEnrollment
{
    public enum TStatus { Normal = 0, Canceled = 1 }

    [Key]
    public Guid Id { get; private set; }
    public int Number { get; private set; }
    public TStatus Status { get; private set; }
    public DateTime EnrollDate { get; private set; }
    public DateTime LastUpdate { get; private set; }
    public ECustomer? Customer { get; private set; }
    public EEvent? Event { get; private set; }
    public bool Participated { get; private set; }
    public Guid UserID { get; private set; }
}