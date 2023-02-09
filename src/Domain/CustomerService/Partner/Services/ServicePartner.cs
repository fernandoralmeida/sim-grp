using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Partner.Interfaces;
using Sim.GRP.Domain.CustomerService.Partner.Models;

namespace Sim.GRP.Domain.CustomerService.Partner.Services;

public class ServicePartner : ServiceBase<EPartner>, IServicePartner
{
    private readonly IRepositoryPartner _reps;
    public ServicePartner(IRepositoryPartner reps)
        : base(reps)
        {
            _reps = reps;
        }

    public async Task<IEnumerable<EPartner>> DoListAsync(Expression<Func<EPartner, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EPartner> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}