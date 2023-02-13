using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryBusiness : RepositoryBase<EBusiness>, IRepositoryBusiness, IDisposable
{
    public RepositoryBusiness(CustomerServiceContext context) : base(context) { }

    public void Dispose() => this.Dispose();

    public async Task<IEnumerable<EBusiness>> DoListAsync(Expression<Func<EBusiness, bool>>? param = null)
    {
        var _query = _dbcontext.CustomerBusinesses!.AsQueryable();

        if (param != null)
            _query = _query
                .Where(param)
                .AsNoTrackingWithIdentityResolution();

        return await _query.ToListAsync();
    }

    public async Task<EBusiness> GetAsync(Guid id)
    {
        var qry = await _dbcontext
                        .CustomerBusinesses!
                        .FirstOrDefaultAsync(s => s.Id == id);

        return qry!;

    }
}