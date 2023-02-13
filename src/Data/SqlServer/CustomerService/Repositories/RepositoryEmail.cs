using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryEmail : RepositoryBase<EEmail>, IRepositoryEmail, IDisposable
{
    public RepositoryEmail(CustomerServiceContext context) : base(context) { }

    public void Dispose() => this.Dispose();

    public async Task<IEnumerable<EEmail>> DoListAsync(Expression<Func<EEmail, bool>>? param = null)
    {
        var _query = _dbcontext.CustomerEmail!.AsQueryable();

        if (param != null)
            _query = _query
                .Where(param)
                .AsNoTrackingWithIdentityResolution();

        return await _query.ToListAsync();
    }

    public async Task<EEmail> GetAsync(Guid id)
    {
        var qry = await _dbcontext
                        .CustomerEmail!
                        .FirstOrDefaultAsync(s => s.Id == id);

        return qry!;
    }
}