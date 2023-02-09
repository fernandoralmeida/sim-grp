using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Domain.CustomerService.Calendar.Interfaces;

public interface IRepositoryWeek : IRepositoryBase<EWeek>
{
    Task<EWeek> GetAsync(Guid id);
    Task<IEnumerable<EWeek>> DoListAsync(Expression<Func<EWeek, bool>>? param = null);
}