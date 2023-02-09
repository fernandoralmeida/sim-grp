using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Calendar.Interfaces;
using Sim.GRP.Domain.CustomerService.Calendar.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryEnrollment : RepositoryBase<EEnrollment>, IRepositoryEnrollment, IDisposable
{
    public RepositoryEnrollment(CustomerServiceContext context) : base(context) {}

    public void Dispose()  => this.Dispose();

    public async Task<IEnumerable<EEnrollment>> DoListAsync(Expression<Func<EEnrollment, bool>>? param = null)
    {
        if (_dbcontext.Enrollment != null)
        {
            var _query = _dbcontext.Enrollment.AsQueryable();

            if (param != null)
                _query = _query
                    .Include(i => i.Customer)
                    .Include(I => I.Schedule)
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

            return await _query.ToListAsync();
        }
        else
            return new List<EEnrollment>();
    }

    public async Task<EEnrollment> GetAsync(Guid id)
    {
        if (_dbcontext.Enrollment != null)
        {
            var qry = await _dbcontext.Enrollment
                                        .Include(i => i.Customer)
                                        .Include(i => i.Schedule)
                                        .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new EEnrollment();
        }
        else
            return new EEnrollment();
    }
}