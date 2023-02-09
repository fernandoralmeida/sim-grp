using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Calls.Interfaces;
using Sim.GRP.Domain.CustomerService.Calls.Models;

namespace Sim.GRP.Domain.CustomerService.Calls.Services;

public class ServiceCalls : ServiceBase<ECalls>, IServiceCalls
{
    private readonly IRepositoryCalls _reps;

    public ServiceCalls(IRepositoryCalls reps)
        :base(reps)
        {
            _reps = reps;
        }

    public async Task<IEnumerable<ECalls>> DoListAsync(Expression<Func<ECalls, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<ECalls> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}