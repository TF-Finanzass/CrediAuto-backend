using CrediAuto.API.Schedules.Domain.Model.ValueObjects;
using CrediAuto.API.Simulations.Domain.Model.Commands;
using CrediAuto.API.Simulations.Interfaces.REST.Resources;

namespace CrediAuto.API.Simulations.Interfaces.REST.Transform;

public static class CreateSimulationCommandFromResourceAssembler
{
    public static CreateSimulationCommand ToCommandFromResource(CreateSimulationResource resource) =>
        new CreateSimulationCommand(
            resource.ClientId,
            resource.CarId,
            resource.Currency,

            resource.VehiclePrice,
            resource.DownPaymentPercent,
            resource.RateType,
            resource.AnnualRate,
            resource.Capitalization,
            resource.PaymentFrequency,
            resource.TermMonths,

            resource.UseAutoFinalInstallment,
            resource.FinalInstallmentPercent,

            resource.GraceTotalMonths,
            resource.GracePartialMonths,

            new InitialCosts(
                resource.InitialCosts.Notarial,
                resource.InitialCosts.Registration,
                resource.InitialCosts.Appraisal,
                resource.InitialCosts.StudyFee,
                resource.InitialCosts.ActivationFee
            ),
            new PeriodicCharges(
                resource.PeriodicCharges.Gps,
                resource.PeriodicCharges.Postage,
                resource.PeriodicCharges.AdministrativeFee
            ),
            resource.DesgravamenInsurancePercent,
            resource.RiskInsurancePercent,

            resource.DiscountRateInput,

            resource.DownPaymentAmount,
            resource.InitialCostsTotal,
            resource.LoanAmount,
            resource.FinalInstallmentAmount,
            resource.NetFinancedBalance,

            resource.PeriodicRate,
            resource.Tea,
            resource.InstallmentAmount,
            resource.TotalPeriods,
            resource.GraceTotalPeriods,
            resource.GracePartialPeriods,

            resource.Van,
            resource.Tir,
            resource.DiscountRate
        );
}