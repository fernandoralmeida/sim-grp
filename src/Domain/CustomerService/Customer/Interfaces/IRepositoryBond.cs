using Sim.GRP.Domain.CustomerService.Customer.Models;
using Sim.GRP.Domain.CustomerService.Base;
using System.Linq.Expressions;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IRepositoryBond : IRepositoryBase<EBonds>
{
    Task<EBonds> GetAsync(Guid id);
    Task<IEnumerable<EBonds>> DoListAsync(Expression<Func<EBonds, bool>>? param = null);
}