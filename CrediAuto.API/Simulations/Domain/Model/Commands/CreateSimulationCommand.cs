using System;

namespace CrediAuto.API.Simulations.Domain.Model.Commands;

public record CreateSimulationCommand(
    decimal Monto,
    decimal TasaTea,
    int NumCuotas,
    decimal MontoCuota,
    DateTimeOffset Fecha
    );