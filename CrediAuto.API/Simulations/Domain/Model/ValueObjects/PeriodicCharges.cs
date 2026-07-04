namespace CrediAuto.API.Simulations.Domain.Model.ValueObjects;

public record PeriodicCharges(
    decimal Gps,
    decimal Postage,
    decimal AdministrativeFee
);