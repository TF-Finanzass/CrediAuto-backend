using CrediAuto.API.Cars.Domain.Model.ValueObjects;

namespace CrediAuto.API.Cars.Domain.Model.Commands;

public record CreateCarCommand(
    string Brand,
    string Model,
    int Year,
    decimal Price,
    string Detail,
    CarStatus Status = CarStatus.Disponible
);