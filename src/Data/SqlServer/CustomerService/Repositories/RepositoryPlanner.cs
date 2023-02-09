using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Calendar.Interfaces;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryPlanner : RepositoryBase<EPlanner>, IRepositoryPlanner, IDisposable
{
    public RepositoryPlanner(CustomerServiceContext context) : base(context) {}

    public void Dispose()  => this.Dispose();

    public async Task<IEnumerable<EPlanner>> DoListAsync(Expression<Func<EPlanner, bool>>? param = null)
    {
        if (_dbcontext.Planner != null)
        {
            var _query = _dbcontext.Planner.AsQueryable();

            if (param != null)
                _query = _query
                    .Include(i => i.Weeks)
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

            return await _query.ToListAsync();
        }
        else
            return new List<EPlanner>();
    }

    public async Task<EPlanner> GetAsync(Guid id)
    {
        if (_dbcontext.Planner != null)
        {
            var qry = await _dbcontext.Planner
                                        .Include(i => i.Weeks)
                                        .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new EPlanner();
        }
        else
            return new EPlanner();
    }
}