using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Schedules.Interfaces.REST.Resources;

namespace CrediAuto.API.Schedules.Interfaces.REST.Transform;

public static class InstallmentResourceFromEntityAssembler
{
    public static InstallmentResource ToResourceFromEntity(Installment entity) =>
        new InstallmentResource(
            entity.Id,
            entity.Number,
            entity.DueDate,
            entity.IsGracePeriod,
            entity.InitialBalance,
            entity.Interest,
            entity.Amortization,
            entity.Insurance,
            entity.InstallmentAmount,
            entity.FinalBalance
        );
}