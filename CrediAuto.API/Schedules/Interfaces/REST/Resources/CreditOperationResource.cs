namespace CrediAuto.API.Schedules.Interfaces.REST.Resources;

public record CreditOperationResource(
    int Id,
    int ClientId,
    int CarId,
    string ClientName,
    string CarLabel,
    string Currency,
    decimal LoanAmount,
    decimal FinalInstallmentAmount,
    decimal NetFinancedBalance,
    decimal Tea,
    decimal PeriodicRate,
    decimal InstallmentAmount,
    int TotalPeriods,
    int GraceTotalPeriods,
    int GracePartialPeriods,
    InitialCostsResource InitialCosts,
    PeriodicChargesResource PeriodicCharges,
    decimal DesgravamenInsurancePercent,
    decimal RiskInsurancePercent,
    List<InstallmentResource> Schedule,
    decimal Van,
    decimal Tir,
    decimal DiscountRate,
    DateTimeOffset? Created,
    DateTimeOffset? Updated
);