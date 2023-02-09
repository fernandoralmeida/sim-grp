using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Calendar.Interfaces;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Domain.CustomerService.Calendar.Services;

public class ServiceEnrollment : ServiceBase<EEnrollment>, IServiceEnrollment
{
    private readonly IRepositoryEnrollment _reps;

    public ServiceEnrollment(IRepositoryEnrollment reps)
        : base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<EEnrollment>> DoListAsync(Expression<Func<EEnrollment, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EEnrollment> GetAsync(Guid id)
        => await _reps.GetAsync(id);
}