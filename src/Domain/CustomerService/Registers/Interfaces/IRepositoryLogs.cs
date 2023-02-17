using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Registers.Models;

namespace Sim.GRP.Domain.CustomerService.Registers.Interfaces;
public interface IRepositoryLogs: IRepositoryBase<ELogs>
{
    Task<ELogs> GetAsync(Guid id);
    Task<IEnumerable<ELogs>> DoListAsync(Expression<Func<ELogs, bool>>? param = null);
}