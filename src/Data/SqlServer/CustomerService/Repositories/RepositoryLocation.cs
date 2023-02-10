using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryLocation : RepositoryBase<ELocation>, IRepositoryLocation, IDisposable
{
    public RepositoryLocation(CustomerServiceContext context) : base(context) {}

    public void Dispose()  => this.Dispose();

    public async Task<IEnumerable<ELocation>> DoListAsync(Expression<Func<ELocation, bool>>? param = null)
    {
        if (_dbcontext.CustomerLocation != null)
        {
            var _query = _dbcontext.CustomerLocation.AsQueryable();

            if (param != null)
                _query = _query
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

            return await _query.ToListAsync();
        }
        else
            return new List<ELocation>();
    }

    public async Task<ELocation> GetAsync(Guid id)
    {
        if (_dbcontext.CustomerLocation != null)
        {
            var qry = await _dbcontext
                            .CustomerLocation
                            .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new ELocation();
        }
        else
            return new ELocation();
    }
}