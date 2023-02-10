using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Services;

public class ServiceLocation : ServiceBase<ELocation>, IServiceLocation
{
    private readonly IRepositoryLocation _reps;
    
    public ServiceLocation(IRepositoryLocation reps)
        : base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<ELocation>> DoListAsync(Expression<Func<ELocation, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<ELocation> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}