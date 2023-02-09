using Sim.GRP.Domain.CustomerService.Customers.Models;
using Sim.GRP.Domain.CustomerService.Base;
using System.Linq.Expressions;

namespace Sim.GRP.Domain.CustomerService.Customers.Interfaces;

public interface IRepositoryEmail : IRepositoryBase<EEmail>
{
    Task<EEmail> GetAsync(Guid id);
    Task<IEnumerable<EEmail>> DoListAsync(Expression<Func<EEmail, bool>>? param = null);
}