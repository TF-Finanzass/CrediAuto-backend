using CrediAuto.API.Cars.Domain.Model.ValueObjects;

namespace CrediAuto.API.Cars.Domain.Model.Commands;

public record CreateCarCommand(
    string Brand,
    string Model,
    int Year,
    decimal Price,
    Currency Currency,
    string Detail,
    CarStatus Status = CarStatus.Disponible
);