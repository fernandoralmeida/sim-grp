
using Sim.GRP.Domain.CustomerService.Owner.Models;
using Sim.GRP.Domain.CustomerService.Partner.Models;

namespace Sim.GRP.Domain.CustomerService.Calendar.Models;

public class ESchedule 
{
    public enum TStatus { Normal = 0, Active = 1, Canceled = 2, Closed = 3 }
    public enum TFormat { Online = 0, InPerson = 1}
    public Guid Id { get; private set; }
    public int Code { get; private set; }
    public TStatus Status { get; private set; }
    public TFormat Format { get; private set; }
    public string? Name { get; private set;}
    public string? Description { get; private set; }
    public EOwner? Manager { get; private set; }
    public EPartner? Partner { get; private set; }
    public int Capacity { get; private set; }    
    public ICollection<EEnrollment>? Subscribers { get; private set; }

    public int Remaining (ICollection<EEnrollment> List) 
        => Capacity - List.Count;
    
    public bool Allowed (int remaining) 
        => remaining < 1 ? false: true;
}