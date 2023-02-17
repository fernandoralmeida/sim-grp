using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Attendance.Interfaces;
using Sim.GRP.Domain.CustomerService.Attendance.Models;

namespace Sim.GRP.Domain.CustomerService.Attendance.Services;

public class ServiceAttendance : ServiceBase<EAttendance>, IServiceAttendance
{
    private readonly IRepositoryAttendance _reps;

    public ServiceAttendance(IRepositoryAttendance reps)
        :base(reps)
        {
            _reps = reps;
        }

    public async Task<IEnumerable<EAttendance>> DoListAsync(Expression<Func<EAttendance, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EAttendance> GetAsync(Guid id)
        => await _reps.GetAsync(id);

    public override Task AddAsync(EAttendance model)
    {
        
        return base.AddAsync(model);
    }
}