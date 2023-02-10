using Sim.GRP.Domain.CustomerService.Customer.Models;
using Sim.GRP.Domain.CustomerService.Base;
using System.Linq.Expressions;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IRepositoryBusiness : IRepositoryBase<EBusiness>
{
    Task<EBusiness> GetAsync(Guid id);
    Task<IEnumerable<EBusiness>> DoListAsync(Expression<Func<EBusiness, bool>>? param = null);
}