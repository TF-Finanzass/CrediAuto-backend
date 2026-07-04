using CrediAuto.API.Schedules.Domain.Model.ValueObjects;

namespace CrediAuto.API.Schedules.Domain.Model.Commands;

public record CreateCreditOperationCommand(
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
    InitialCosts InitialCosts,
    PeriodicCharges PeriodicCharges,
    decimal DesgravamenInsurancePercent,
    decimal RiskInsurancePercent,
    decimal Van,
    decimal Tir,
    decimal DiscountRate,
    List<InstallmentData> Schedule
);