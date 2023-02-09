
using System.Linq.Expressions;

namespace Sim.GRP.Domain.CustomerService.Base;
public class ServiceBase<Model> : IServiceBase<Model> where Model : class
{
    private readonly IRepositoryBase<Model> _reps;

    public ServiceBase(IRepositoryBase<Model> repository)
    {
        _reps = repository;
    }

    public virtual async Task AddAsync(Model model)
        => await _reps.AddAsync(model);

    public async Task<IEnumerable<Model>> DoListSingleAsync(Expression<Func<Model, bool>>? param = null)
        => await _reps.DoListSingleAsync(param);

    public async Task RemoveAsync(Model model)
        => await _reps.RemoveAsync(model);

    public async Task UpdateAsync(Model model)
        => await _reps.UpdateAsync(model);
}