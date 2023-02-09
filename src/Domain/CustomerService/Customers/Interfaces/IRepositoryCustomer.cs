using Sim.GRP.Domain.CustomerService.Customers.Models;
using Sim.GRP.Domain.CustomerService.Base;
using System.Linq.Expressions;

namespace Sim.GRP.Domain.CustomerService.Customers.Interfaces;

public interface IRepositoryCustomer : IRepositoryBase<ECustomer>
{
    Task<ECustomer> GetAsync(Guid id);
    Task<IEnumerable<ECustomer>> DoListAsync(Expression<Func<ECustomer, bool>>? param = null);
}