using System;
using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Schedules.Interfaces.REST.Resources;

public record CreateInstallmentResource(
    [Required] int Number,
    [Required] DateTime DueDate,
    [Required] bool IsGracePeriod,
    [Required] decimal InitialBalance,
    [Required] decimal Interest,
    [Required] decimal Amortization,
    [Required] decimal Insurance,
    [Required] decimal InstallmentAmount,
    [Required] decimal FinalBalance
);