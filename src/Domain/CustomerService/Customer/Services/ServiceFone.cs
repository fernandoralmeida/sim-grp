using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Services;

public class ServiceFone :  ServiceBase<EFone>, IServiceFone
{
    private readonly IRepositoryFone _reps;
    
    public ServiceFone(IRepositoryFone reps)
        :base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<EFone>> DoListAsync(Expression<Func<EFone, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EFone> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}