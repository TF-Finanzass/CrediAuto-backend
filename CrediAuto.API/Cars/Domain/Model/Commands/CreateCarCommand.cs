namespace CrediAuto.API.Cars.Domain.Model.Commands;

public record CreateCarCommand(
    string Brand,
    string Model,
    int Year,
    decimal Price,
    string FuelType,
    string Transmission,
    string Detail
);