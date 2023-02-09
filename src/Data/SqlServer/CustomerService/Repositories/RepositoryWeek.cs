using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Calendar.Interfaces;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryWeek : RepositoryBase<EWeek>, IRepositoryWeek, IDisposable
{
    public RepositoryWeek(CustomerServiceContext context) : base(context) {}

    public void Dispose()  => this.Dispose();

    public async Task<IEnumerable<EWeek>> DoListAsync(Expression<Func<EWeek, bool>>? param = null)
    {
        if (_dbcontext.Week != null)
        {
            var _query = _dbcontext.Week.AsQueryable();

            if (param != null)
                _query = _query
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

            return await _query.ToListAsync();
        }
        else
            return new List<EWeek>();
    }

    public async Task<EWeek> GetAsync(Guid id)
    {
        if (_dbcontext.Week != null)
        {
            var qry = await _dbcontext.Week
                            .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new EWeek();
        }
        else
            return new EWeek();
    }
}