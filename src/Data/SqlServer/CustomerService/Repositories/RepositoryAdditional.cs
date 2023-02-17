using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryAdditional : RepositoryBase<EAdditional>, IRepositoryAdditional, IDisposable
{
    public RepositoryAdditional(CustomerServiceContext context) : base(context) { }

    public void Dispose() => this.Dispose();

    public async Task<IEnumerable<EAdditional>> DoListAsync(Expression<Func<EAdditional, bool>>? param = null)
    {
        var _query = _dbcontext.CustomerAdditionals!.AsQueryable();

        if (param != null)
            _query = _query
                .Where(param)
                .AsNoTrackingWithIdentityResolution();

        return await _query.ToListAsync();
    }

    public async Task<EAdditional> GetAsync(Guid id)
    {
        var qry = await _dbcontext
                        .CustomerAdditionals!
                        .FirstOrDefaultAsync(s => s.Id == id);

        return qry!;

    }
}