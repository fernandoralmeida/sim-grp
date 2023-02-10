using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Calendar.Interfaces;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryEvent : RepositoryBase<EEvent>, IRepositoryEvent, IDisposable
{
    public RepositoryEvent(CustomerServiceContext context) : base(context) {}

    public void Dispose()  => this.Dispose();

    public async Task<IEnumerable<EEvent>> DoListAsync(Expression<Func<EEvent, bool>>? param = null)
    {
        if (_dbcontext.Events != null)
        {
            var _query = _dbcontext.Events.AsQueryable();

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
            return new List<EEvent>();
    }

    public async Task<EEvent> GetAsync(Guid id)
    {
        if (_dbcontext.Events != null)
        {
            var qry = await _dbcontext
                            .Events
                            .Include(i => i.Manager)
                            .Include(i => i.Partner)
                            .Include(i => i.Subscribers)
                            .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new EEvent();
        }
        else
            return new EEvent();
    }
}