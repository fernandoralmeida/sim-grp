using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Helpers;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Services;

public class ServiceAdditional : ServiceBase<EAdditional>, IServiceAdditional
{
    private readonly IRepositoryAdditional _reps;

    public ServiceAdditional(IRepositoryAdditional reps)
        : base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<EAdditional>> DoListAsync(Expression<Func<EAdditional, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EAdditional> GetAsync(Guid id)
        => await _reps.GetAsync(id);
    
}