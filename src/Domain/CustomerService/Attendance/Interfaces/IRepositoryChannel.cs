using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Attendance.Models;

namespace Sim.GRP.Domain.CustomerService.Attendance.Interfaces;

public interface IRepositoryChannel : IRepositoryBase<EChannel>
{
    Task<EChannel> GetAsync(Guid id);
    Task<IEnumerable<EChannel>> DoListAsync(Expression<Func<EChannel, bool>>? param = null);
}