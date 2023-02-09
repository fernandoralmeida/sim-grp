using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Owner.Interfaces;
using Sim.GRP.Domain.CustomerService.Owner.Models;

namespace Sim.GRP.Domain.CustomerService.Owner.Services;

public class ServiceOwner : ServiceBase<EOwner>, IServiceOwner
{
    private readonly IRepositoryOwner _reps;
    public ServiceOwner(IRepositoryOwner reps)
        : base(reps)
        {
            _reps = reps;
        }

    public async Task<IEnumerable<EOwner>> DoListAsync(Expression<Func<EOwner, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EOwner> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}