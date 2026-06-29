using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Simulations.Interfaces.REST.Resources;

public record CreateSimulationResource(
    [Required] decimal Monto,
    [Required] decimal TasaTea,
    [Required] int NumCuotas,
    [Required] decimal MontoCuota,
    [Required] DateTimeOffset Fecha
    );