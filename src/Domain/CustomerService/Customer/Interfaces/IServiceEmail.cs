using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IServiceEmail : IServiceBase<EEmail>
{
    Task<EEmail> GetAsync(Guid id);
    Task<IEnumerable<EEmail>> DoListAsync(Expression<Func<EEmail, bool>>? param = null);
}