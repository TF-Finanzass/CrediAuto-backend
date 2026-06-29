namespace CrediAuto.API.Simulations.Interfaces.REST.Resources;

public record SimulationResource(
    int Id,
    decimal Monto,
    decimal TasaTea,
    int NumCuotas,
    decimal MontoCuota,
    DateTimeOffset Fecha,
    DateTimeOffset? Created,
    DateTimeOffset? Updated
    );