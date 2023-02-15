using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Helpers;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Services;

public class ServiceCompany : ServiceBase<ECompany>, IServiceCompany
{
    private readonly IRepositoryCompany _reps;

    public ServiceCompany(IRepositoryCompany reps)
        : base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<ECompany>> DoListAsync(Expression<Func<ECompany, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<ECompany> GetAsync(Guid id)
        => await _reps.GetAsync(id);

    public override async Task AddAsync(ECompany model)
    {
        if (model.Validate(model).status == false)
            throw new Exception($"Erro: {model.Validate(model).message}");

        foreach (var current in await _reps.DoListSingleAsync(s => s.Document == model.Document))
            throw new Exception($"Erro: Company {model.Name} Document {model.Document} Exist!");

        await _reps.AddAsync(model);
    }

    
}