using System.Linq;
using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Schedules.Interfaces.REST.Resources;

namespace CrediAuto.API.Schedules.Interfaces.REST.Transform;

public static class CreditOperationResourceFromEntityAssembler
{
    public static CreditOperationResource ToResourceFromEntity(CreditOperation entity) =>
        new CreditOperationResource(
            entity.Id,
            entity.ClientId,
            entity.CarId,
            entity.ClientName,
            entity.CarLabel,
            entity.FinancedAmount,
            entity.Tea,
            entity.PeriodicRate,
            entity.InstallmentAmount,
            entity.TotalPeriods,
            entity.GracePeriods,
            entity.Schedule.Select(InstallmentResourceFromEntityAssembler.ToResourceFromEntity).ToList(),
            entity.CreatedDate,
            entity.UpdatedDate
        );
}