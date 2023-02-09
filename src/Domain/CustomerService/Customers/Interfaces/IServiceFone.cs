using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customers.Models;

namespace Sim.GRP.Domain.CustomerService.Customers.Interfaces;

public interface IServiceFone : IServiceBase<EFone>
{
    Task<EFone> GetAsync(Guid id);
    Task<IEnumerable<EFone>> DoListAsync(Expression<Func<EFone, bool>>? param = null);
}