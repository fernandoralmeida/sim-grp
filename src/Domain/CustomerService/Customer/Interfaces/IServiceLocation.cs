using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IServiceLocation : IServiceBase<ELocation>
{
    Task<ELocation> GetAsync(Guid id);
    Task<IEnumerable<ELocation>> DoListAsync(Expression<Func<ELocation, bool>>? param = null);
}