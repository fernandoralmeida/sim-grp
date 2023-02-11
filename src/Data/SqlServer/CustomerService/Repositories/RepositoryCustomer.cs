using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryCustomers : RepositoryBase<ECustomer>, IRepositoryCustomer, IDisposable
{
    public RepositoryCustomers(CustomerServiceContext context) : base(context) { }

    public void Dispose() => this.Dispose();

    public async Task<IEnumerable<ECustomer>> DoListAsync(Expression<Func<ECustomer, bool>>? param = null)
    {

        var _query = _dbcontext.Customers!.AsQueryable();

        if (param != null)
            _query = _query
                    .Include(i => i.Profile)
                    .Include(i => i.Business)
                    .Include(i => i.Fones)
                    .Include(i => i.Emails)
                    .Include(i => i.Locations)
                    .Include(i => i.Attendances)
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

        return await _query.ToListAsync();

    }

    public async Task<ECustomer> GetAsync(Guid id)
        => await _dbcontext.Customers!
                            .Include(i => i.Profile)
                            .Include(i => i.Business)
                            .Include(i => i.Fones)
                            .Include(i => i.Emails)
                            .Include(i => i.Locations)
                            .Include(i => i.Attendances)
                            .FirstOrDefaultAsync(s => s.Id == id);

            
                

    
}