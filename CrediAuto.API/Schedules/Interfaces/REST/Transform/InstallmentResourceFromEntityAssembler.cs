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
            entity.PeriodType,
            entity.IsGracePeriod,
            entity.InitialBalance,
            entity.Interest,
            entity.Amortization,
            entity.DesgravamenInsurance,
            entity.InstallmentAmount,
            entity.FinalBalance,
            entity.RiskInsurance,
            entity.Gps,
            entity.Postage,
            entity.AdministrativeFee,
            entity.FinalInstallmentInitialBalance,
            entity.FinalInstallmentInterest,
            entity.FinalInstallmentAmortization,
            entity.FinalInstallmentFinalBalance,
            entity.TotalCashOutflow
        );
}