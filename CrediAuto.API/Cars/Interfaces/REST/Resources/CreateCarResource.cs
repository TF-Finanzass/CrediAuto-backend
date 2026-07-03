using System.ComponentModel.DataAnnotations;
using CrediAuto.API.Cars.Domain.Model.ValueObjects;

namespace CrediAuto.API.Cars.Interfaces.REST.Resources;

public record CreateCarResource(
    [Required] string Brand,
    [Required] string Model,
    [Required] int Year,
    [Required] decimal Price,
    string Detail,
    CarStatus? Status = null
);