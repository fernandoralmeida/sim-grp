using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Calendar.Interfaces;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Domain.CustomerService.Calendar.Services;

public class ServiceWeek : ServiceBase<EWeek>, IServiceWeek
{
    private readonly IRepositoryWeek _reps;

    public ServiceWeek(IRepositoryWeek reps)
        : base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<EWeek>> DoListAsync(Expression<Func<EWeek, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EWeek> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}