using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IServiceCustomer : IServiceBase<ECustomer>
{
    Task<ECustomer> GetAsync(Guid id);
    Task<IEnumerable<ECustomer>> DoListAsync(Expression<Func<ECustomer, bool>>? param = null);
}