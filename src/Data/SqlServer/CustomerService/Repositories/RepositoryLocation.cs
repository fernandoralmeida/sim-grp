using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryLocation : RepositoryBase<ELocation>, IRepositoryLocation, IDisposable
{
    public RepositoryLocation(CustomerServiceContext context) : base(context) { }

    public void Dispose() => this.Dispose();

    public async Task<IEnumerable<ELocation>> DoListAsync(Expression<Func<ELocation, bool>>? param = null)
    {
        var _query = _dbcontext.CustomerLocation!.AsQueryable();

        if (param != null)
            _query = _query
                .Where(param)
                .AsNoTrackingWithIdentityResolution();

        return await _query.ToListAsync();

    }

    public async Task<ELocation> GetAsync(Guid id)
    {
        var qry = await _dbcontext
                        .CustomerLocation!
                        .FirstOrDefaultAsync(s => s.Id == id);


        return qry!;
    }
}