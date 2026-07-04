using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Schedules.Interfaces.REST.Resources;

public record PeriodicChargesResource(
    [Required] decimal Gps,
    [Required] decimal Postage,
    [Required] decimal AdministrativeFee
);