using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customers.Interfaces;
using Sim.GRP.Domain.CustomerService.Customers.Models;

namespace Sim.GRP.Domain.CustomerService.Customers.Services;

public class ServiceCustomer : ServiceBase<ECustomer>, IServiceCustomer
{
    private readonly IRepositoryCustomer _reps;
    
    public ServiceCustomer(IRepositoryCustomer reps)
        :base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<ECustomer>> DoListAsync(Expression<Func<ECustomer, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<ECustomer> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}