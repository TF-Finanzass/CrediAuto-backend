using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Cars.Interfaces.REST.Resources;

public record CreateCarResource(
    [Required] string Brand,
    [Required] string Model,
    [Required] int Year,
    [Required] decimal Price,
    [Required] string FuelType,
    [Required] string Transmission,
    string Detail
);