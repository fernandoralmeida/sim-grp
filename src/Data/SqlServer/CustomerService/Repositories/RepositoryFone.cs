using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Customers.Interfaces;
using Sim.GRP.Domain.CustomerService.Customers.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryFone : RepositoryBase<EFone>, IRepositoryFone, IDisposable
{
    public RepositoryFone(CustomerServiceContext context) : base(context) {}

    public void Dispose()  => this.Dispose();

    public async Task<IEnumerable<EFone>> DoListAsync(Expression<Func<EFone, bool>>? param = null)
    {
        if (_dbcontext.CustomerFone != null)
        {
            var _query = _dbcontext.CustomerFone.AsQueryable();

            if (param != null)
                _query = _query
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

            return await _query.ToListAsync();
        }
        else
            return new List<EFone>();
    }

    public async Task<EFone> GetAsync(Guid id)
    {
        if (_dbcontext.CustomerFone != null)
        {
            var qry = await _dbcontext
                            .CustomerFone
                            .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new EFone();
        }
        else
            return new EFone();
    }
}