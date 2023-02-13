using System.Linq.Expressions;
using Sim.GRP.Domain.CustomerService.Base;
using Sim.GRP.Domain.CustomerService.Customer.Helpers;
using Sim.GRP.Domain.CustomerService.Customer.Interfaces;
using Sim.GRP.Domain.CustomerService.Customer.Models;

namespace Sim.GRP.Domain.CustomerService.Customer.Services;

public class ServiceCustomer : ServiceBase<ECustomer>, IServiceCustomer
{
    private readonly IRepositoryCustomer _reps;

    public ServiceCustomer(IRepositoryCustomer reps)
        : base(reps)
    {
        _reps = reps;
    }

    public async Task<IEnumerable<ECustomer>> DoListAsync(Expression<Func<ECustomer, bool>>? param = null)
        => await _reps.DoListAsync(param);

    public async Task<ECustomer> GetAsync(Guid id)
        => await _reps.GetAsync(id);

    public override async Task AddAsync(ECustomer model)
    {
        if (model.Validate().value == false)
            throw new Exception($"Erro: {model.Validate().message}");

        foreach (var current in await _reps.DoListSingleAsync(s => s.Document == model.Document))
            switch (current.Exist(model))
            {
                case false:
                    await base.AddAsync(model);
                    break;

                case true:
                    break;
                    throw new Exception($"Erro: Customer {model.Id} Exist!");
            }
    }
}