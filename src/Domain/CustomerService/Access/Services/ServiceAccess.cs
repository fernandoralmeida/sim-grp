using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Access.Interfaces;
using Sim.GRP.Domain.CustomerService.Access.Models;
using Sim.GRP.Domain.CustomerService.Base;

namespace Sim.GRP.Domain.CustomerService.Access.Services;

public class ServiceAccess : ServiceBase<EAccess>, IServiceAccess
{
    private readonly IRepositoryAccess _reps;

    public ServiceAccess(IRepositoryAccess reps)
        :base(reps)
        {
            _reps = reps;
        }

    public Task<IEnumerable<EAccess>> DoListAsync(Expression<Func<EAccess, bool>>? param = null)
        => _reps.DoListAsync(param);

    public Task<EAccess> GetAsync(Guid id)
        => _reps.GetAsync(id);
}