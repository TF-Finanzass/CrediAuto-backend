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
    public Currency Currency { get; private set; }
    public string Detail { get; private set; }
    public CarStatus Status { get; private set; }

    protected Car()
    {
        Brand = string.Empty;
        Model = string.Empty;
        Year = 0;
        Price = 0;
        Currency = Currency.PEN;
        Detail = string.Empty;
        Status = CarStatus.Disponible;
    }

    public Car(CreateCarCommand command)
    {
        Brand = command.Brand;
        Model = command.Model;
        Year = command.Year;
        Price = command.Price;
        Currency = command.Currency;
        Detail = command.Detail;
        Status = command.Status;
    }

    public void UpdateStatus(CarStatus status)
    {
        Status = status;
    }
}