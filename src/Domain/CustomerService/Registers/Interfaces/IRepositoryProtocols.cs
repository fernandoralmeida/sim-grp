using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Registers.Models;

namespace Sim.GRP.Domain.CustomerService.Registers.Interfaces;
public interface IRepositoryProtocol : IRepositoryBase<EProtocols>
{
    Task<EProtocols> GetAsync(Guid id);
    Task<IEnumerable<EProtocols>> DoListAsync(Expression<Func<EProtocols, bool>>? param = null);
}