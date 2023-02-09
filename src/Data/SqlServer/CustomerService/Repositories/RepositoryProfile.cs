using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Customers.Interfaces;
using Sim.GRP.Domain.CustomerService.Customers.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryProfile : RepositoryBase<EProfile>, IRepositoryProfile, IDisposable
{
    public RepositoryProfile(CustomerServiceContext context) : base(context) {}

    public void Dispose()  => this.Dispose();

    public async Task<IEnumerable<EProfile>> DoListAsync(Expression<Func<EProfile, bool>>? param = null)
    {
        if (_dbcontext.CustomerProfile != null)
        {
            var _query = _dbcontext.CustomerProfile.AsQueryable();

            if (param != null)
                _query = _query
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

            return await _query.ToListAsync();
        }
        else
            return new List<EProfile>();
    }

    public async Task<EProfile> GetAsync(Guid id)
    {
        if (_dbcontext.CustomerProfile != null)
        {
            var qry = await _dbcontext
                            .CustomerProfile
                            .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new EProfile();
        }
        else
            return new EProfile();
    }
}