namespace CrediAuto.API.Schedules.Domain.Model.ValueObjects;

public record PeriodicCharges(
    decimal Gps,
    decimal Postage,
    decimal AdministrativeFee
);