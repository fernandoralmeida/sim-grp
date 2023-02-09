using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Calendar.Interfaces;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositorySchedule : RepositoryBase<ESchedule>, IRepositorySchedule, IDisposable
{
    public RepositorySchedule(CustomerServiceContext context) : base(context) {}

    public void Dispose()  => this.Dispose();

    public async Task<IEnumerable<ESchedule>> DoListAsync(Expression<Func<ESchedule, bool>>? param = null)
    {
        if (_dbcontext.Schedule != null)
        {
            var _query = _dbcontext.Schedule.AsQueryable();

            if (param != null)
                _query = _query
                    .Include(i => i.Manager)
                    .Include(i => i.Partner)
                    .Include(i => i.Subscribers)
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

            return await _query.ToListAsync();
        }
        else
            return new List<ESchedule>();
    }

    public async Task<ESchedule> GetAsync(Guid id)
    {
        if (_dbcontext.Schedule != null)
        {
            var qry = await _dbcontext
                            .Schedule
                            .Include(i => i.Manager)
                            .Include(i => i.Partner)
                            .Include(i => i.Subscribers)
                            .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new ESchedule();
        }
        else
            return new ESchedule();
    }
}