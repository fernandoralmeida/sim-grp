using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Registers.Interfaces;
using Sim.GRP.Domain.CustomerService.Registers.Models;

namespace Sim.GRP.Domain.CustomerService.Registers.Services;

public class ServiceProtocols : ServiceBase<EProtocols>, IServiceProtocols
{
    private readonly IRepositoryProtocol _reps;

    public ServiceProtocols(IRepositoryProtocol reps)
        : base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<EProtocols>> DoListAsync(Expression<Func<EProtocols, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<EProtocols> GetAsync(Guid id)
        => await _reps.GetAsync(id);

    public override async Task AddAsync(EProtocols model)
    {
        do
        {
            await _reps.AddAsync(model);
        }
        while (await Validate(model.New()) == true);
    }

    private async Task<bool> Validate(string protocol)
    {
        foreach (var items in await _reps.DoListSingleAsync(s => s.Protocol == protocol))
            if (items.Protocol == protocol)
                return false;

        return true;
    }
}