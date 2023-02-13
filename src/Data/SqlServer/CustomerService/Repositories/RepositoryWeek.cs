using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Calendar.Interfaces;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryWeek : RepositoryBase<EWeek>, IRepositoryWeek, IDisposable
{
    public RepositoryWeek(CustomerServiceContext context) : base(context) { }

    public void Dispose() => this.Dispose();

    public async Task<IEnumerable<EWeek>> DoListAsync(Expression<Func<EWeek, bool>>? param = null)
    {
        var _query = _dbcontext.EventWeek!.AsQueryable();

        if (param != null)
            _query = _query
                .Where(param)
                .AsNoTrackingWithIdentityResolution();

        return await _query.ToListAsync();
    }

    public async Task<EWeek> GetAsync(Guid id)
    {
        var qry = await _dbcontext.EventWeek!
                        .FirstOrDefaultAsync(s => s.Id == id);


        return qry!;
    }
}