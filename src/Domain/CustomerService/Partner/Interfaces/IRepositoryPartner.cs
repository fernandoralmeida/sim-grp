using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Partner.Models;

namespace Sim.GRP.Domain.CustomerService.Partner.Interfaces;

public interface IRepositoryPartner : IRepositoryBase<EPartner>
{
    Task<EPartner> GetAsync(Guid id);
    Task<IEnumerable<EPartner>> DoListAsync(Expression<Func<EPartner, bool>>? param = null);
}