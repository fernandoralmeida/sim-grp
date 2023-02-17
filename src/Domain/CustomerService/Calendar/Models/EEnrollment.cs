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
    public ICollection<ECustomer>? Customer { get; private set; }
    public EEvent? Event { get; private set; }
    public bool Participated { get; private set; }
    public Guid UserID { get; private set; }

    public EEnrollment() { }
    public EEnrollment(Guid id, int number, TStatus status,
        DateTime enrolldate, DateTime lastupdate,
        ICollection<ECustomer> customer,
        EEvent eevent, bool participated, Guid userid)
    {
        Id = id;
        Number = number;
        Status = status;
        EnrollDate = enrolldate;
        LastUpdate = lastupdate;
        Customer = customer;
        Event = eevent;
        Participated = participated;
        UserID = userid;
    }
    public bool EnrollExist(EEnrollment enroll, ICollection<EEnrollment> enrollments)
    {
        foreach(var e in enroll.Customer!)
            foreach(var enrolls in enrollments)
                foreach(var exist in enrolls.Customer!.Where(s => s.Document == e.Document))
                    return true;
                    
        return false;        
    }
}