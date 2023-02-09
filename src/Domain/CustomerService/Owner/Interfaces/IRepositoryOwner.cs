using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Owner.Models;

namespace Sim.GRP.Domain.CustomerService.Owner.Interfaces;

public interface IRepositoryOwner : IRepositoryBase<EOwner>
{
    Task<EOwner> GetAsync(Guid id);
    Task<IEnumerable<EOwner>> DoListAsync(Expression<Func<EOwner, bool>>? param = null);
}