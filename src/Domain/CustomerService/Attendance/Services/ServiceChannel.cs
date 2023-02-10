using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Attendance.Interfaces;
using Sim.GRP.Domain.CustomerService.Attendance.Models;

namespace Sim.GRP.Domain.CustomerService.Calls.Services;

public class ServiceChannel : ServiceBase<EChannel>, IServiceChannel
{
    private readonly IRepositoryChannel _reps;

    public ServiceChannel(IRepositoryChannel reps)
        :base(reps)
        {
            _reps = reps;
        }

    public async Task<IEnumerable<EChannel>> DoListAsync(Expression<Func<EChannel, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EChannel> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}