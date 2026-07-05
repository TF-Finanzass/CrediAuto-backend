using CrediAuto.API.Schedules.Domain.Model.Commands;
using CrediAuto.API.Schedules.Domain.Model.ValueObjects;
using CrediAuto.API.Schedules.Interfaces.REST.Resources;

namespace CrediAuto.API.Schedules.Interfaces.REST.Transform;

public static class CreateCreditOperationCommandFromResourceAssembler
{
    public static CreateCreditOperationCommand ToCommandFromResource(CreateCreditOperationResource resource) =>
        new CreateCreditOperationCommand(
            resource.ClientId,
            resource.CarId,
            resource.ClientName,
            resource.CarLabel,
            resource.Currency,
            resource.LoanAmount,
            resource.FinalInstallmentAmount,
            resource.NetFinancedBalance,
            resource.Tea,
            resource.PeriodicRate,
            resource.InstallmentAmount,
            resource.TotalPeriods,
            resource.GraceTotalPeriods,
            resource.GracePartialPeriods,
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
            resource.Van,
            resource.Tir,
            resource.DiscountRate,
            resource.Schedule.Select(i => new InstallmentData(
                i.Number,
                i.DueDate,
                i.PeriodType,
                i.IsGracePeriod,
                i.InitialBalance,
                i.Interest,
                i.Amortization,
                i.DesgravamenInsurance,
                i.InstallmentAmount,
                i.FinalBalance,
                i.RiskInsurance,
                i.Gps,
                i.Postage,
                i.AdministrativeFee,
                i.FinalInstallmentInitialBalance,
                i.FinalInstallmentInterest,
                i.FinalInstallmentAmortization,
                i.FinalInstallmentDesgravamenInsurance,
                i.FinalInstallmentFinalBalance,
                i.TotalCashOutflow
            )).ToList()
        );
}