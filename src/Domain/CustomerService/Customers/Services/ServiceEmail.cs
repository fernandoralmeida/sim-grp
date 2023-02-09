using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customers.Interfaces;
using Sim.GRP.Domain.CustomerService.Customers.Models;

namespace Sim.GRP.Domain.CustomerService.Customers.Services;

public class ServiceEmail : ServiceBase<EEmail>, IServiceEmail
{
    private readonly IRepositoryEmail _reps;
    
    public ServiceEmail(IRepositoryEmail reps)
        :base(reps)
    {
        _reps = reps;
    }

    public Task<IEnumerable<EEmail>> DoListAsync(Expression<Func<EEmail, bool>>? param = null)
        => _reps.DoListAsync(param);

    public Task<EEmail> GetAsync(Guid id)
        => _reps.GetAsync(id);
}