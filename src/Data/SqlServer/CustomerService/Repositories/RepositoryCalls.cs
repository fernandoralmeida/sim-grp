using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Calls.Interfaces;
using Sim.GRP.Domain.CustomerService.Calls.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryCalls : RepositoryBase<ECalls>, IRepositoryCalls, IDisposable
{
    public RepositoryCalls(CustomerServiceContext context) : base(context) {}

    public void Dispose()  => this.Dispose();

    public async Task<IEnumerable<ECalls>> DoListAsync(Expression<Func<ECalls, bool>>? param = null)
    {
        if (_dbcontext.Call!= null)
        {
            var _query = _dbcontext.Call.AsQueryable();

            if (param != null)
                _query = _query
                    .Include(i => i.Customers)
                    .Include(i => i.Domain)
                    .Include(i => i.Channel)
                    .Include(i => i.Services)
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

            return await _query.ToListAsync();
        }
        else
            return new List<ECalls>();
    }

    public async Task<ECalls> GetAsync(Guid id)
    {
        if (_dbcontext.Call != null)
        {
            var qry = await _dbcontext
                            .Call
                            .Include(i => i.Customers)
                            .Include(i => i.Domain)
                            .Include(i => i.Channel)
                            .Include(i => i.Services)
                            .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new ECalls();
        }
        else
            return new ECalls();
    }
}