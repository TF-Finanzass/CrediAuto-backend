namespace CrediAuto.API.Schedules.Domain.Model.Commands;

public record InstallmentData(
    int Number,
    DateTime DueDate,
    string PeriodType,
    bool IsGracePeriod,
    decimal InitialBalance,
    decimal Interest,
    decimal Amortization,
    decimal DesgravamenInsurance,
    decimal InstallmentAmount,
    decimal FinalBalance,
    decimal RiskInsurance,
    decimal Gps,
    decimal Postage,
    decimal AdministrativeFee,
    decimal FinalInstallmentInitialBalance,
    decimal FinalInstallmentInterest,
    decimal FinalInstallmentAmortization,
    decimal FinalInstallmentDesgravamenInsurance,
    decimal FinalInstallmentFinalBalance,
    decimal TotalCashOutflow
);