using System.Collections.Generic;
using System.Threading.Tasks;
using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Schedules.Domain.Model.Queries;

namespace CrediAuto.API.Schedules.Domain.Services;

public interface ICreditOperationQueryService
{
    Task<CreditOperation?> Handle(GetCreditOperationByIdQuery query);
    Task<IEnumerable<CreditOperation>> Handle(GetAllCreditOperationsQuery query);
    Task<IEnumerable<CreditOperation>> Handle(GetCreditOperationsByClientIdQuery query);
    Task<IEnumerable<CreditOperation>> Handle(GetCreditOperationsByCarIdQuery query);
}