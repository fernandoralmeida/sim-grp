using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Base;

namespace Sim.GRP.Data.SqlServer.CustomerService.Base;

public class RepositoryBase<Model> : IRepositoryBase<Model> where Model : class
{
    protected readonly CustomerServiceContext _dbcontext;

    public RepositoryBase(CustomerServiceContext context)
    {
        _dbcontext = context;
    }
    public async Task AddAsync(Model model)
    {
        await _dbcontext.Set<Model>().AddAsync(model);
        await _dbcontext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Model>> DoListSingleAsync(Expression<Func<Model, bool>>? param = null)
    {
        var _query = _dbcontext.Set<Model>().AsQueryable();

        if (param != null)
            _query = _query
                .Where(param)
                .AsNoTrackingWithIdentityResolution();

        return await _query.ToListAsync();
    }

    public async Task<Model> DoSingleAsync(Guid id)
    {
        var _query = await _dbcontext.Set<Model>().FindAsync(id);
        return _query!;
    }

    public async Task RemoveAsync(Model model)
    {
        _dbcontext.Set<Model>().Remove(model);
        await _dbcontext.SaveChangesAsync();
    }
    public async Task UpdateAsync(Model model)
    {
        _dbcontext.Entry(model).State = EntityState.Modified;
        await _dbcontext.SaveChangesAsync();
    }
}