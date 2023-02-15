using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IServiceCompany : IServiceBase<ECompany>
{
    Task<ECompany> GetAsync(Guid id);
    Task<IEnumerable<ECompany>> DoListAsync(Expression<Func<ECompany, bool>>? param = null);
}