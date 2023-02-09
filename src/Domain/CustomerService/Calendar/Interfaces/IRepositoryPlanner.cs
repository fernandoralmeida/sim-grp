using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Domain.CustomerService.Calendar.Interfaces;

public interface IRepositoryPlanner : IRepositoryBase<EPlanner>
{
    Task<EPlanner> GetAsync(Guid id);
    Task<IEnumerable<EPlanner>> DoListAsync(Expression<Func<EPlanner, bool>>? param = null);
}