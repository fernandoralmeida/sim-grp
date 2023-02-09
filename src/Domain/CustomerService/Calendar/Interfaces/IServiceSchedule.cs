using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Domain.CustomerService.Calendar.Interfaces;

public interface IServiceSchedule : IServiceBase<ESchedule>
{
    Task<ESchedule> GetAsync(Guid id);
    Task<IEnumerable<ESchedule>> DoListAsync(Expression<Func<ESchedule, bool>>? param = null);
}