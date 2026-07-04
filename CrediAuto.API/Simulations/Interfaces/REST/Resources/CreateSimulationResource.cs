using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Simulations.Interfaces.REST.Resources;

public record CreateSimulationResource(
    [Required] int ClientId,
    [Required] int CarId,
    [Required] string Currency,

    [Required] decimal VehiclePrice,
    [Required] decimal DownPaymentPercent,
    [Required] string RateType,
    [Required] decimal AnnualRate,
    [Required] string Capitalization,
    [Required] string PaymentFrequency,
    [Required] int TermMonths,

    [Required] bool UseAutoFinalInstallment,
    [Required] decimal FinalInstallmentPercent,

    [Required] int GraceTotalMonths,
    [Required] int GracePartialMonths,

    [Required] SimulationInitialCostsResource InitialCosts,
    [Required] SimulationPeriodicChargesResource PeriodicCharges,
    [Required] decimal DesgravamenInsurancePercent,
    [Required] decimal RiskInsurancePercent,

    [Required] decimal DiscountRateInput,

    [Required] decimal DownPaymentAmount,
    [Required] decimal InitialCostsTotal,
    [Required] decimal LoanAmount,
    [Required] decimal FinalInstallmentAmount,
    [Required] decimal NetFinancedBalance,

    [Required] decimal PeriodicRate,
    [Required] decimal Tea,
    [Required] decimal InstallmentAmount,
    [Required] int TotalPeriods,
    [Required] int GraceTotalPeriods,
    [Required] int GracePartialPeriods,

    [Required] decimal Van,
    [Required] decimal Tir,
    [Required] decimal DiscountRate
);