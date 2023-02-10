using Sim.GRP.Domain.CustomerService.Customer.Models;
using Sim.GRP.Domain.CustomerService.Base;
using System.Linq.Expressions;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IRepositoryFone : IRepositoryBase<EFone>
{
    Task<EFone> GetAsync(Guid id);
    Task<IEnumerable<EFone>> DoListAsync(Expression<Func<EFone, bool>>? param = null);
}