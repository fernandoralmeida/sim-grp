using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IServiceBond : IServiceBase<EBonds>
{
    Task<EBonds> GetAsync(Guid id);
    Task<IEnumerable<EBonds>> DoListAsync(Expression<Func<EBonds, bool>>? param = null);
}