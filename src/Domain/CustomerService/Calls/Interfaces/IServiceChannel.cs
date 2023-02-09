using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Calls.Models;

namespace Sim.GRP.Domain.CustomerService.Calls.Interfaces;

public interface IServiceChannel : IRepositoryBase<EChannel>
{
    Task<EChannel> GetAsync(Guid id);
    Task<IEnumerable<EChannel>> DoListAsync(Expression<Func<EChannel, bool>>? param = null);
}