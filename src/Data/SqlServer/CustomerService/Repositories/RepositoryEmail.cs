using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryEmail : RepositoryBase<EEmail>, IRepositoryEmail, IDisposable
{
    public RepositoryEmail(CustomerServiceContext context) : base(context) {}

    public void Dispose()  => this.Dispose();

    public async Task<IEnumerable<EEmail>> DoListAsync(Expression<Func<EEmail, bool>>? param = null)
    {
        if (_dbcontext.CustomerEmail != null)
        {
            var _query = _dbcontext.CustomerEmail.AsQueryable();

            if (param != null)
                _query = _query
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

            return await _query.ToListAsync();
        }
        else
            return new List<EEmail>();
    }

    public async Task<EEmail> GetAsync(Guid id)
    {
        if (_dbcontext.CustomerEmail != null)
        {
            var qry = await _dbcontext
                            .CustomerEmail
                            .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new EEmail();
        }
        else
            return new EEmail();
    }
}