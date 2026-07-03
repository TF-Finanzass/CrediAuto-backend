using System;
using System.Collections.Generic;

namespace CrediAuto.API.Schedules.Interfaces.REST.Resources;

public record CreditOperationResource(
    int Id,
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
    decimal Van,
    decimal Tir,
    decimal DiscountRate,
    List<InstallmentResource> Schedule,
    DateTimeOffset? Created,
    DateTimeOffset? Updated
);