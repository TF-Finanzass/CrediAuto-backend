namespace CrediAuto.API.Simulations.Interfaces.REST.Resources;

public record SimulationResource(
    int Id,
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

    SimulationInitialCostsResource InitialCosts,
    SimulationPeriodicChargesResource PeriodicCharges,
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
    decimal DiscountRate,

    DateTimeOffset? Created,
    DateTimeOffset? Updated
);