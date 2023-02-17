using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryBond : RepositoryBase<EBonds>, IRepositoryBond, IDisposable
{
    public RepositoryBond(CustomerServiceContext context) : base(context) { }

    public void Dispose() => this.Dispose();

    public async Task<IEnumerable<EBonds>> DoListAsync(Expression<Func<EBonds, bool>>? param = null)
    {

        var _query = _dbcontext.Bonds!.AsQueryable();

        if (param != null)
            _query = _query
                    .Include(i => i.Customer)
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

        return await _query.ToListAsync();

    }

    public async Task<EBonds> GetAsync(Guid id)
    {
        var _query = await _dbcontext!.Bonds!
                            .Include(i => i.Customer)
                            .FirstOrDefaultAsync(s => s.Id == id);
        return _query!;
    }

            
                

    
}