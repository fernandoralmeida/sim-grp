using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Owner.Interfaces;
using Sim.GRP.Domain.CustomerService.Owner.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryOwner : RepositoryBase<EOwner>, IRepositoryOwner, IDisposable
{
    public RepositoryOwner(CustomerServiceContext context) : base(context) { }

    public void Dispose() => this.Dispose();

    public async Task<IEnumerable<EOwner>> DoListAsync(Expression<Func<EOwner, bool>>? param = null)
    {
        var _query = _dbcontext.Owners!.AsQueryable();

        if (param != null)
            _query = _query
                .Where(param)
                .AsNoTrackingWithIdentityResolution();

        return await _query.ToListAsync();

    }

    public async Task<EOwner> GetAsync(Guid id)
    {
        var qry = await _dbcontext.Owners!
                        .FirstOrDefaultAsync(s => s.Id == id);

        return qry!;
    }
}