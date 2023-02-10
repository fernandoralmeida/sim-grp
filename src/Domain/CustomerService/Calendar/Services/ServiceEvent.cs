using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Domain.CustomerService.Calendar.Interfaces;

public class ServiceEvent : ServiceBase<EEvent>, IServiceEvent
{
    private readonly IRepositoryEvent _reps;

    public ServiceEvent(IRepositoryEvent reps)
        :base(reps)
        {
            _reps = reps;
        }

    public async Task<IEnumerable<EEvent>> DoListAsync(Expression<Func<EEvent, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EEvent> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}