using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Domain.CustomerService.Calendar.Interfaces;

public class ServiceSchedule : ServiceBase<ESchedule>, IServiceSchedule
{
    private readonly IRepositorySchedule _reps;

    public ServiceSchedule(IRepositorySchedule reps)
        :base(reps)
        {
            _reps = reps;
        }

    public async Task<IEnumerable<ESchedule>> DoListAsync(Expression<Func<ESchedule, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<ESchedule> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}