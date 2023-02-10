using Sim.GRP.Domain.CustomerService.Customer.Models;
using Sim.GRP.Domain.CustomerService.Base;
using System.Linq.Expressions;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IRepositoryLocation : IRepositoryBase<ELocation>
{
    Task<ELocation> GetAsync(Guid id);
    Task<IEnumerable<ELocation>> DoListAsync(Expression<Func<ELocation, bool>>? param = null);
}