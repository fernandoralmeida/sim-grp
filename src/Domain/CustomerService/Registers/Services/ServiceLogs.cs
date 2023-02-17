using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Registers.Interfaces;
using Sim.GRP.Domain.CustomerService.Registers.Models;

namespace Sim.GRP.Domain.CustomerService.Registers.Services;

public class ServiceLogs : ServiceBase<ELogs>, IServiceLogs
{
    private readonly IRepositoryLogs _reps;

    public ServiceLogs(IRepositoryLogs reps)
        : base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<ELogs>> DoListAsync(Expression<Func<ELogs, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<ELogs> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}