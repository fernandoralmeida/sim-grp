using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryProfile : RepositoryBase<EProfile>, IRepositoryProfile, IDisposable
{
    public RepositoryProfile(CustomerServiceContext context) : base(context) { }

    public void Dispose() => this.Dispose();

    public async Task<IEnumerable<EProfile>> DoListAsync(Expression<Func<EProfile, bool>>? param = null)
    {
        var _query = _dbcontext.CustomerProfile!.AsQueryable();

        if (param != null)
            _query = _query
                .Where(param)
                .AsNoTrackingWithIdentityResolution();

        return await _query.ToListAsync();
    }

    public async Task<EProfile> GetAsync(Guid id)
    {
        var qry = await _dbcontext
                        .CustomerProfile!
                        .FirstOrDefaultAsync(s => s.Id == id);

        return qry!;

    }
}