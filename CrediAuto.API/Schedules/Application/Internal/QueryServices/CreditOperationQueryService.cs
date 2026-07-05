using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Schedules.Domain.Model.Queries;
using CrediAuto.API.Schedules.Domain.Repositories;
using CrediAuto.API.Schedules.Domain.Services;

namespace CrediAuto.API.Schedules.Application.Internal.QueryServices;

public class CreditOperationQueryService(ICreditOperationRepository creditOperationRepository)
    : ICreditOperationQueryService
{
    public async Task<CreditOperation?> Handle(GetCreditOperationByIdQuery query)
        => await creditOperationRepository.FindByIdWithScheduleAsync(query.Id);

    public async Task<IEnumerable<CreditOperation>> Handle(GetAllCreditOperationsQuery query)
        => await creditOperationRepository.ListWithScheduleAsync();

    public async Task<IEnumerable<CreditOperation>> Handle(GetCreditOperationsByClientIdQuery query)
        => await creditOperationRepository.FindByClientIdAsync(query.ClientId);

    public async Task<IEnumerable<CreditOperation>> Handle(GetCreditOperationsByCarIdQuery query)
        => await creditOperationRepository.FindByCarIdAsync(query.CarId);
}