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
            entity.Currency,
            entity.LoanAmount,
            entity.FinalInstallmentAmount,
            entity.NetFinancedBalance,
            entity.Tea,
            entity.PeriodicRate,
            entity.InstallmentAmount,
            entity.TotalPeriods,
            entity.GraceTotalPeriods,
            entity.GracePartialPeriods,
            new InitialCostsResource(
                entity.InitialCosts.Notarial,
                entity.InitialCosts.Registration,
                entity.InitialCosts.Appraisal,
                entity.InitialCosts.StudyFee,
                entity.InitialCosts.ActivationFee
            ),
            new PeriodicChargesResource(
                entity.PeriodicCharges.Gps,
                entity.PeriodicCharges.Postage,
                entity.PeriodicCharges.AdministrativeFee
            ),
            entity.DesgravamenInsurancePercent,
            entity.RiskInsurancePercent,
            entity.Schedule.Select(InstallmentResourceFromEntityAssembler.ToResourceFromEntity).ToList(),
            entity.Van,
            entity.Tir,
            entity.DiscountRate,
            entity.CreatedDate,
            entity.UpdatedDate
        );
}