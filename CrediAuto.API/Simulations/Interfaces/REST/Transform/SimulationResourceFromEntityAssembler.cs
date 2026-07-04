using CrediAuto.API.Simulations.Domain.Model.Aggregates;
using CrediAuto.API.Simulations.Interfaces.REST.Resources;

namespace CrediAuto.API.Simulations.Interfaces.REST.Transform;

public static class SimulationResourceFromEntityAssembler
{
    public static SimulationResource ToResourceFromEntity(Simulation entity) =>
        new SimulationResource(
            entity.Id,
            entity.ClientId,
            entity.CarId,
            entity.Currency,

            entity.VehiclePrice,
            entity.DownPaymentPercent,
            entity.RateType,
            entity.AnnualRate,
            entity.Capitalization,
            entity.PaymentFrequency,
            entity.TermMonths,

            entity.UseAutoFinalInstallment,
            entity.FinalInstallmentPercent,

            entity.GraceTotalMonths,
            entity.GracePartialMonths,

            new SimulationInitialCostsResource(
                entity.InitialCosts.Notarial,
                entity.InitialCosts.Registration,
                entity.InitialCosts.Appraisal,
                entity.InitialCosts.StudyFee,
                entity.InitialCosts.ActivationFee
            ),
            new SimulationPeriodicChargesResource(
                entity.PeriodicCharges.Gps,
                entity.PeriodicCharges.Postage,
                entity.PeriodicCharges.AdministrativeFee
            ),
            entity.DesgravamenInsurancePercent,
            entity.RiskInsurancePercent,

            entity.DiscountRateInput,

            entity.DownPaymentAmount,
            entity.InitialCostsTotal,
            entity.LoanAmount,
            entity.FinalInstallmentAmount,
            entity.NetFinancedBalance,

            entity.PeriodicRate,
            entity.Tea,
            entity.InstallmentAmount,
            entity.TotalPeriods,
            entity.GraceTotalPeriods,
            entity.GracePartialPeriods,

            entity.Van,
            entity.Tir,
            entity.DiscountRate,

            entity.CreatedDate,
            entity.UpdatedDate
        );
}