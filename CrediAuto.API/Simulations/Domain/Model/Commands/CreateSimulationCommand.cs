using CrediAuto.API.Schedules.Domain.Model.ValueObjects;

namespace CrediAuto.API.Simulations.Domain.Model.Commands;

public record CreateSimulationCommand(
    int ClientId,
    int CarId,
    string Currency,

    decimal VehiclePrice,
    decimal DownPaymentPercent,
    string RateType,
    decimal AnnualRate,
    string Capitalization,
    string PaymentFrequency,
    int TermMonths,

    bool UseAutoFinalInstallment,
    decimal FinalInstallmentPercent,

    int GraceTotalMonths,
    int GracePartialMonths,

    InitialCosts InitialCosts,
    PeriodicCharges PeriodicCharges,
    decimal DesgravamenInsurancePercent,
    decimal RiskInsurancePercent,

    decimal DiscountRateInput,

    decimal DownPaymentAmount,
    decimal InitialCostsTotal,
    decimal LoanAmount,
    decimal FinalInstallmentAmount,
    decimal NetFinancedBalance,

    decimal PeriodicRate,
    decimal Tea,
    decimal InstallmentAmount,
    int TotalPeriods,
    int GraceTotalPeriods,
    int GracePartialPeriods,

    decimal Van,
    decimal Tir,
    decimal DiscountRate
);