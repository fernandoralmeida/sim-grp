using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Partner.Interfaces;
using Sim.GRP.Domain.CustomerService.Partner.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryPartner : RepositoryBase<EPartner>, IRepositoryPartner, IDisposable
{
    public RepositoryPartner(CustomerServiceContext context) : base(context) {}

    public void Dispose()  => this.Dispose();

    public async Task<IEnumerable<EPartner>> DoListAsync(Expression<Func<EPartner, bool>>? param = null)
    {
        if (_dbcontext.Partners != null)
        {
            var _query = _dbcontext.Partners.AsQueryable();

            if (param != null)
                _query = _query
                        .Include(i => i.Domain)
                        .Where(param)
                        .AsNoTrackingWithIdentityResolution();

            return await _query.ToListAsync();
        }
        else
            return new List<EPartner>();
    }

    public async Task<EPartner> GetAsync(Guid id)
    {
        if (_dbcontext.Partners != null)
        {
            var qry = await _dbcontext
                            .Partners
                            .Include(i => i.Domain)
                            .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new EPartner();
        }
        else
            return new EPartner();
    }
}