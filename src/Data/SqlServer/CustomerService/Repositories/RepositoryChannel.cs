using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sim.GRP.Data.SqlServer.CustomerService.Base;
using Sim.GRP.Data.SqlServer.CustomerService.Context;
using Sim.GRP.Domain.CustomerService.Attendance.Interfaces;
using Sim.GRP.Domain.CustomerService.Attendance.Models;

namespace Sim.GRP.Data.SqlServer.CustomerService.Repositories;

public class RepositoryChannel : RepositoryBase<EChannel>, IRepositoryChannel, IDisposable
{
    public RepositoryChannel(CustomerServiceContext context) : base(context) { }

    public void Dispose() => this.Dispose();

    public async Task<IEnumerable<EChannel>> DoListAsync(Expression<Func<EChannel, bool>>? param = null)
    {
        if (_dbcontext.AttendanceChannels != null)
        {
            var _query = _dbcontext.AttendanceChannels.AsQueryable();

            if (param != null)
                _query = _query
                    .Include(i => i.Domain)
                    .Where(param)
                    .AsNoTrackingWithIdentityResolution();

            return await _query.ToListAsync();
        }
        else
            return new List<EChannel>();
    }

    public async Task<EChannel> GetAsync(Guid id)
    {
        if (_dbcontext.AttendanceChannels != null)
        {
            var qry = await _dbcontext
                            .AttendanceChannels
                            .Include(i => i.Domain)
                            .FirstOrDefaultAsync(s => s.Id == id);

            if (qry != null)
                return qry;
            else
                return new EChannel();
        }
        else
            return new EChannel();
    }
}