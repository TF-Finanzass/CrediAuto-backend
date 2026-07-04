using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Schedules.Interfaces.REST.Resources;

public record CreateInstallmentResource(
    [Required] int Number,
    [Required] DateTime DueDate,
    [Required] string PeriodType,
    [Required] bool IsGracePeriod,
    [Required] decimal InitialBalance,
    [Required] decimal Interest,
    [Required] decimal Amortization,
    [Required] decimal DesgravamenInsurance,
    [Required] decimal InstallmentAmount,
    [Required] decimal FinalBalance,
    [Required] decimal RiskInsurance,
    [Required] decimal Gps,
    [Required] decimal Postage,
    [Required] decimal AdministrativeFee,
    [Required] decimal FinalInstallmentInitialBalance,
    [Required] decimal FinalInstallmentInterest,
    [Required] decimal FinalInstallmentAmortization,
    [Required] decimal FinalInstallmentFinalBalance,
    [Required] decimal TotalCashOutflow
);