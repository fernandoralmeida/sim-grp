using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Access.Models;
using Sim.GRP.Domain.CustomerService.Base;

namespace Sim.GRP.Domain.CustomerService.Access.Interfaces;

public interface IServiceAccess : IServiceBase<EAccess>
{
    Task<EAccess> GetAsync(Guid id);
    Task<IEnumerable<EAccess>> DoListAsync(Expression<Func<EAccess, bool>>? param = null);
}