using System;

namespace CrediAuto.API.Schedules.Domain.Model.Commands;

public record InstallmentData(
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