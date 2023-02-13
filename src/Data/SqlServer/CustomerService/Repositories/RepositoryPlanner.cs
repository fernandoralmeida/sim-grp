using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Calendar.Interfaces;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryPlanner : RepositoryBase<EPlanner>, IRepositoryPlanner, IDisposable
{
    public RepositoryPlanner(CustomerServiceContext context) : base(context) { }

    public void Dispose() => this.Dispose();

    public async Task<IEnumerable<EPlanner>> DoListAsync(Expression<Func<EPlanner, bool>>? param = null)
    {
        var _query = _dbcontext.EventPlanners!.AsQueryable();

        if (param != null)
            _query = _query
                .Include(i => i.Weeks)
                .Where(param)
                .AsNoTrackingWithIdentityResolution();

        return await _query.ToListAsync();
    }

    public async Task<EPlanner> GetAsync(Guid id)
    {
        var qry = await _dbcontext.EventPlanners!
                                    .Include(i => i.Weeks)
                                    .FirstOrDefaultAsync(s => s.Id == id);

        return qry!;
    }
}