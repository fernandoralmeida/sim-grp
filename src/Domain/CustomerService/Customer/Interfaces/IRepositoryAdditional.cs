using Sim.GRP.Domain.CustomerService.Customer.Models;
using Sim.GRP.Domain.CustomerService.Base;
using System.Linq.Expressions;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IRepositoryAdditional : IRepositoryBase<EAdditional>
{
    Task<EAdditional> GetAsync(Guid id);
    Task<IEnumerable<EAdditional>> DoListAsync(Expression<Func<EAdditional, bool>>? param = null);
}