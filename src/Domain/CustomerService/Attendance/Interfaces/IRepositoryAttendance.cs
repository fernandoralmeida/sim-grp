using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Attendance.Models;

namespace Sim.GRP.Domain.CustomerService.Attendance.Interfaces;

public interface IRepositoryAttendance : IRepositoryBase<EAttendance>
{
    Task<EAttendance> GetAsync(Guid id);
    Task<IEnumerable<EAttendance>> DoListAsync(Expression<Func<EAttendance, bool>>? param = null);
}