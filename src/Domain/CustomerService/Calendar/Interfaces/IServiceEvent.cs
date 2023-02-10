using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Domain.CustomerService.Calendar.Interfaces;

public interface IServiceEvent : IServiceBase<EEvent>
{
    Task<EEvent> GetAsync(Guid id);
    Task<IEnumerable<EEvent>> DoListAsync(Expression<Func<EEvent, bool>>? param = null);
}