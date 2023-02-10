using Sim.GRP.Domain.CustomerService.Customer.Models;
using Sim.GRP.Domain.CustomerService.Base;
using System.Linq.Expressions;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IRepositoryProfile : IRepositoryBase<EProfile>
{
    Task<EProfile> GetAsync(Guid id);
    Task<IEnumerable<EProfile>> DoListAsync(Expression<Func<EProfile, bool>>? param = null);
}