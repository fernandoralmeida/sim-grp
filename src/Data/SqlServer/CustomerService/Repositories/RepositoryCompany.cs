using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryCompany : RepositoryBase<ECompany>, IRepositoryCompany, IDisposable
{
    public RepositoryCompany(CustomerServiceContext context) : base(context) { }

    public void Dispose() => this.Dispose();

    public async Task<IEnumerable<ECompany>> DoListAsync(Expression<Func<ECompany, bool>>? param = null)
    {

        var _query = _dbcontext.Companies!.AsQueryable();

        if (param != null)
            _query = _query
                    .Include(i => i.Business)
                    .Include(i => i.Fones)
                    .Include(i => i.Emails)
                    .Include(i => i.Locations)
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

        return await _query.ToListAsync();

    }

    public async Task<ECompany> GetAsync(Guid id)
    {
        var _query = await _dbcontext!.Companies!
                            .Include(i => i.Business)
                            .Include(i => i.Fones)
                            .Include(i => i.Emails)
                            .Include(i => i.Locations)
                            .FirstOrDefaultAsync(s => s.Id == id);
        return _query!;
    }

            
                

    
}