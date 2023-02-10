using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Attendance.Models;

namespace Sim.GRP.Domain.CustomerService.Attendance.Interfaces;

public interface IServiceService : IRepositoryBase<EService>
{
    Task<EService> GetAsync(Guid id);
    Task<IEnumerable<EService>> DoListAsync(Expression<Func<EService, bool>>? param = null);
}