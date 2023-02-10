using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Interfaces;

public interface IServiceBusiness : IServiceBase<EBusiness> 
{
    Task<EBusiness> GetAsync(Guid id);
    Task<IEnumerable<EBusiness>> DoListAsync(Expression<Func<EBusiness, bool>>? param = null);
}