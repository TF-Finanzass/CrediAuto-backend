using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Schedules.Interfaces.REST.Resources;

public record CreateCreditOperationResource(
    [Required] int ClientId,
    [Required] int CarId,
    [Required] string ClientName,
    [Required] string CarLabel,
    [Required] decimal FinancedAmount,
    [Required] decimal Tea,
    [Required] decimal PeriodicRate,
    [Required] decimal InstallmentAmount,
    [Required] int TotalPeriods,
    [Required] int GracePeriods,
    [Required] List<CreateInstallmentResource> Schedule
);