using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Attendance.Interfaces;
using Sim.GRP.Domain.CustomerService.Attendance.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryAttendance : RepositoryBase<EAttendance>, IRepositoryAttendance, IDisposable
{
    public RepositoryAttendance(CustomerServiceContext context) : base(context) { }

    public void Dispose() => this.Dispose();

    public async Task<IEnumerable<EAttendance>> DoListAsync(Expression<Func<EAttendance, bool>>? param = null)
    {
        var _query = _dbcontext.Attendances!.AsQueryable();

        if (param != null)
            _query = _query
                .Include(i => i.Customer)
                .Include(i => i.Domain)
                .Include(i => i.Channel)
                .Include(i => i.Services)
                .Where(param)
                .AsNoTrackingWithIdentityResolution();

        return await _query.ToListAsync();
    }

    public async Task<EAttendance> GetAsync(Guid id)
    {
        var qry = await _dbcontext
                        .Attendances!
                        .Include(i => i.Customer)
                        .Include(i => i.Domain)
                        .Include(i => i.Channel)
                        .Include(i => i.Services)
                        .FirstOrDefaultAsync(s => s.Id == id);

        return qry!;
    }
}