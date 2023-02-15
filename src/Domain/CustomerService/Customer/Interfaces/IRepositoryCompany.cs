using Sim.GRP.Domain.CustomerService.Customer.Models;
using Sim.GRP.Domain.CustomerService.Base;
using System.Linq.Expressions;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IRepositoryCompany : IRepositoryBase<ECompany>
{
    Task<ECompany> GetAsync(Guid id);
    Task<IEnumerable<ECompany>> DoListAsync(Expression<Func<ECompany, bool>>? param = null);
}