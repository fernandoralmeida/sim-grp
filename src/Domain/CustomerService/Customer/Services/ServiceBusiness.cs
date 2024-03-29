using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Services;

public class ServiceBusiness : ServiceBase<EBusiness>, IServiceBusiness
{
    private readonly IRepositoryBusiness _reps;
    
    public ServiceBusiness(IRepositoryBusiness reps)
        :base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<EBusiness>> DoListAsync(Expression<Func<EBusiness, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EBusiness> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}