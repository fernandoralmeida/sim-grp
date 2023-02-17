using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Registers.Models;

namespace Sim.GRP.Domain.CustomerService.Registers.Interfaces;
public interface IRepositoryExceptions: IRepositoryBase<EExceptions>
{
    Task<EExceptions> GetAsync(Guid id);
    Task<IEnumerable<EExceptions>> DoListAsync(Expression<Func<EExceptions, bool>>? param = null);
}