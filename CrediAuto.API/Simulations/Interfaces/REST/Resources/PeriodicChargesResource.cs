using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Simulations.Interfaces.REST.Resources;

public record SimulationPeriodicChargesResource(
    [Required] decimal Gps,
    [Required] decimal Postage,
    [Required] decimal AdministrativeFee
);