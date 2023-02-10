using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Calls.Interfaces;
using Sim.GRP.Domain.CustomerService.Calls.Models;

namespace Sim.GRP.Domain.CustomerService.Calls.Services;

public class ServiceService : ServiceBase<EService>, IServiceService
{
    private readonly IRepositoryService _reps;

    public ServiceService(IRepositoryService reps)
        :base(reps)
        {
            _reps = reps;
        }

    public async Task<IEnumerable<EService>> DoListAsync(Expression<Func<EService, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EService> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}