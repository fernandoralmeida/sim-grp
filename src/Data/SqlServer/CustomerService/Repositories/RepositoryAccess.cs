using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Access.Interfaces;
using Sim.GRP.Domain.CustomerService.Access.Models;
using Sim.GRP.Data.SqlServer.CustomerService.Base;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryAccess : RepositoryBase<EAccess>, IRepositoryAccess, IDisposable
{

    public RepositoryAccess(CustomerServiceContext context)
        : base(context) { }

    public void Dispose() => this.Dispose();

    public async Task<IEnumerable<EAccess>> DoListAsync(Expression<Func<EAccess, bool>>? param = null)
    {

        var _query = _dbcontext.Access!.AsQueryable();

        if (param != null)
            _query = _query
                .Where(param)
                .AsNoTrackingWithIdentityResolution();

        return await _query.ToListAsync();

    }

    public async Task<EAccess> GetAsync(Guid id)
    {
        var qry = await _dbcontext.Access!.FirstOrDefaultAsync(s => s.Id == id);
        return qry!;
    }
}