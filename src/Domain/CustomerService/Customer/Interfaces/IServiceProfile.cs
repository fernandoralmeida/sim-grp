using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IServiceProfile : IServiceBase<EProfile>
{
    Task<EProfile> GetAsync(Guid id);
    Task<IEnumerable<EProfile>> DoListAsync(Expression<Func<EProfile, bool>>? param = null);
}