using System.Linq.Expressions;

namespace Sim.GRP.Domain.CustomerService.Base;

public interface IServiceBase<Model> where Model : class 
{
    Task AddAsync(Model model);
    Task UpdateAsync(Model model);
    Task RemoveAsync(Model model);
    Task<IEnumerable<Model>> DoListSingleAsync(Expression<Func<Model, bool>>? param = null);
    Task<Model> DoSingleAsync(Guid id);
}