using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Calls.Interfaces;
using Sim.GRP.Domain.CustomerService.Calls.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryServices : RepositoryBase<EService>, IRepositoryService, IDisposable
{
    public RepositoryServices(CustomerServiceContext context) : base(context) {}

    public void Dispose()  => this.Dispose();

    public async Task<IEnumerable<EService>> DoListAsync(Expression<Func<EService, bool>>? param = null)
    {
        if (_dbcontext.Service != null)
        {
            var _query = _dbcontext.Service.AsQueryable();

            if (param != null)
                _query = _query
                    .Include(i => i.Domain)
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

            return await _query.ToListAsync();
        }
        else
            return new List<EService>();
    }

    public async Task<EService> GetAsync(Guid id)
    {
        if (_dbcontext.Service != null)
        {
            var qry = await _dbcontext
                            .Service
                            .Include(i => i.Domain)
                               .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new EService();
        }
        else
            return new EService();
    }
}