using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IServiceAdditional : IServiceBase<EAdditional>
{
    Task<EAdditional> GetAsync(Guid id);
    Task<IEnumerable<EAdditional>> DoListAsync(Expression<Func<EAdditional, bool>>? param = null);
}