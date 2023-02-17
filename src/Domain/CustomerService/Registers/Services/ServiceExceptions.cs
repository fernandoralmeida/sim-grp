using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Registers.Interfaces;
using Sim.GRP.Domain.CustomerService.Registers.Models;

namespace Sim.GRP.Domain.CustomerService.Registers.Services;

public class ServiceExceptions : ServiceBase<EExceptions>, IServiceExceptions
{
    private readonly IRepositoryExceptions _reps;

    public ServiceExceptions(IRepositoryExceptions reps)
        : base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<EExceptions>> DoListAsync(Expression<Func<EExceptions, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EExceptions> GetAsync(Guid id)
        => await _reps.GetAsync(id);

}