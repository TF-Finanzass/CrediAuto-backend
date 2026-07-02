using CrediAuto.API.Cars.Domain.Model.Commands;
using CrediAuto.API.Cars.Domain.Model.ValueObjects;

namespace CrediAuto.API.Cars.Domain.Model.Aggregates;

public partial class Car : CarAudit
{
    public int Id { get; }
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    public decimal Price { get; private set; }
    public string FuelType { get; private set; }
    public string Transmission { get; private set; }
    public string Detail { get; private set; }
    public CarStatus Status { get; private set; }

    protected Car()
    {
        Brand = string.Empty;
        Model = string.Empty;
        Year = 0;
        Price = 0;
        FuelType = string.Empty;
        Transmission = string.Empty;
        Detail = string.Empty;
        Status = CarStatus.Disponible;
    }

    public Car(CreateCarCommand command)
    {
        Brand = command.Brand;
        Model = command.Model;
        Year = command.Year;
        Price = command.Price;
        FuelType = command.FuelType;
        Transmission = command.Transmission;
        Detail = command.Detail;
        Status = CarStatus.Disponible;
    }

    public void UpdateStatus(CarStatus status)
    {
        Status = status;
    }
}