using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Calendar.Interfaces;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Domain.CustomerService.Calendar.Services;

public class ServicePlanner : ServiceBase<EPlanner>, IServicePlanner
{
    private readonly IRepositoryPlanner _reps;

    public ServicePlanner(IRepositoryPlanner reps)
        : base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<EPlanner>> DoListAsync(Expression<Func<EPlanner, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EPlanner> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}