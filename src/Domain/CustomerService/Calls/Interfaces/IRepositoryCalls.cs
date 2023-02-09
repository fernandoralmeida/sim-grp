using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Calls.Models;

namespace Sim.GRP.Domain.CustomerService.Calls.Interfaces;

public interface IRepositoryCalls : IRepositoryBase<ECalls>
{
    Task<ECalls> GetAsync(Guid id);
    Task<IEnumerable<ECalls>> DoListAsync(Expression<Func<ECalls, bool>>? param = null);
}