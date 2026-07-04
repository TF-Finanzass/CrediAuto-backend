using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Schedules.Interfaces.REST.Resources;

public record CreateCreditOperationResource(
    [Required] int ClientId,
    [Required] int CarId,
    [Required] string ClientName,
    [Required] string CarLabel,
    [Required] string Currency,
    [Required] decimal LoanAmount,
    [Required] decimal FinalInstallmentAmount,
    [Required] decimal NetFinancedBalance,
    [Required] decimal Tea,
    [Required] decimal PeriodicRate,
    [Required] decimal InstallmentAmount,
    [Required] int TotalPeriods,
    [Required] int GraceTotalPeriods,
    [Required] int GracePartialPeriods,
    [Required] InitialCostsResource InitialCosts,
    [Required] PeriodicChargesResource PeriodicCharges,
    [Required] decimal DesgravamenInsurancePercent,
    [Required] decimal RiskInsurancePercent,
    [Required] decimal Van,
    [Required] decimal Tir,
    [Required] decimal DiscountRate,
    [Required] List<CreateInstallmentResource> Schedule
);