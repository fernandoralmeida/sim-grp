using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Customers.Interfaces;
using Sim.GRP.Domain.CustomerService.Customers.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryCustomers : RepositoryBase<ECustomer>, IRepositoryCustomer, IDisposable
{
    public RepositoryCustomers(CustomerServiceContext context) : base(context) {}

    public void Dispose()  => this.Dispose();

    public async Task<IEnumerable<ECustomer>> DoListAsync(Expression<Func<ECustomer, bool>>? param = null)
    {
        if (_dbcontext.Customer!= null)
        {
            var _query = _dbcontext.Customer.AsQueryable();

            if (param != null)
                _query = _query
                        .Include(i => i.Profile)
                        .Include(i => i.Business)
                        .Include(i => i.Fones)
                        .Include(i => i.Emails)
                        .Include(i => i.Locations)
                        .Include(i => i.Calls)
                        .Where(param)
                        .AsNoTrackingWithIdentityResolution();

            return await _query.ToListAsync();
        }
        else
            return new List<ECustomer>();
    }

    public async Task<ECustomer> GetAsync(Guid id)
    {
        if (_dbcontext.Customer != null)
        {
            var qry = await _dbcontext.Customer
                            .Include(i => i.Profile)
                            .Include(i => i.Business)
                            .Include(i => i.Fones)
                            .Include(i => i.Emails)
                            .Include(i => i.Locations)
                            .Include(i => i.Calls)
                            .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new ECustomer();
        }
        else
            return new ECustomer();
    }
}