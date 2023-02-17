using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Services;

public class ServiceBond : ServiceBase<EBonds>, IServiceBond
{
    private readonly IRepositoryBond _reps;
    
    public ServiceBond(IRepositoryBond reps)
        : base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<EBonds>> DoListAsync(Expression<Func<EBonds, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EBonds> GetAsync(Guid id)
        => await _reps.GetAsync(id);

}