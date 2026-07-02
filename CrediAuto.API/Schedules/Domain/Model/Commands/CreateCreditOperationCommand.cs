using System.Collections.Generic;

namespace CrediAuto.API.Schedules.Domain.Model.Commands;

public record CreateCreditOperationCommand(
    int ClientId,
    int CarId,
    string ClientName,
    string CarLabel,
    decimal FinancedAmount,
    decimal Tea,
    decimal PeriodicRate,
    decimal InstallmentAmount,
    int TotalPeriods,
    int GracePeriods,
    List<InstallmentData> Schedule
);