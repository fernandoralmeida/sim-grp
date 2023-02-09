using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customers.Interfaces;
using Sim.GRP.Domain.CustomerService.Customers.Models;

namespace Sim.GRP.Domain.CustomerService.Customers.Services;

public class ServiceProfile : ServiceBase<EProfile>, IServiceProfile
{
    private readonly IRepositoryProfile _reps;
    
    public ServiceProfile(IRepositoryProfile reps)
        : base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<EProfile>> DoListAsync(Expression<Func<EProfile, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EProfile> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}