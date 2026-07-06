using System.ComponentModel.DataAnnotations;
using CrediAuto.API.Cars.Domain.Model.ValueObjects;

namespace CrediAuto.API.Cars.Interfaces.REST.Resources;

public record UpdateCarResource(
    [Required] string Brand,
    [Required] string Model,
    [Required] int Year,
    [Required] decimal Price,
    [Required] Currency Currency,
    string Detail,
    [Required] CarStatus Status
);