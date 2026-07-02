using System.ComponentModel.DataAnnotations;
using CrediAuto.API.Cars.Domain.Model.ValueObjects;

namespace CrediAuto.API.Cars.Interfaces.REST.Resources;

public record UpdateCarStatusResource(
    [Required] CarStatus Status
);