using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Attendance.Interfaces;
using Sim.GRP.Domain.CustomerService.Attendance.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryAttendance : RepositoryBase<EAttendance>, IRepositoryAttendance, IDisposable
{
    public RepositoryAttendance(CustomerServiceContext context) : base(context) {}

    public void Dispose()  => this.Dispose();

    public async Task<IEnumerable<EAttendance>> DoListAsync(Expression<Func<EAttendance, bool>>? param = null)
    {
        if (_dbcontext.Attendances != null)
        {
            var _query = _dbcontext.Attendances.AsQueryable();

            if (param != null)
                _query = _query
                    .Include(i => i.Customers)
                    .Include(i => i.Domain)
                    .Include(i => i.Channel)
                    .Include(i => i.Services)
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

            return await _query.ToListAsync();
        }
        else
            return new List<EAttendance>();
    }

    public async Task<EAttendance> GetAsync(Guid id)
    {
        if (_dbcontext.Attendances!= null)
        {
            var qry = await _dbcontext
                            .Attendances
                            .Include(i => i.Customers)
                            .Include(i => i.Domain)
                            .Include(i => i.Channel)
                            .Include(i => i.Services)
                            .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new EAttendance();
        }
        else
            return new EAttendance();
    }
}