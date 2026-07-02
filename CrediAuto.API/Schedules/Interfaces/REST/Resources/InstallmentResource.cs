using System;

namespace CrediAuto.API.Schedules.Interfaces.REST.Resources;

public record InstallmentResource(
    int Id,
    int Number,
    DateTime DueDate,
    bool IsGracePeriod,
    decimal InitialBalance,
    decimal Interest,
    decimal Amortization,
    decimal Insurance,
    decimal InstallmentAmount,
    decimal FinalBalance
);