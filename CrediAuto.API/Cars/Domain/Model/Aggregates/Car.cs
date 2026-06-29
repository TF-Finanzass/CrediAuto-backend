using CrediAuto.API.Cars.Domain.Model.Commands;

namespace CrediAuto.API.Cars.Domain.Model.Aggregates;

public partial class Car : CarAudit
{
    public int Id { get; }
    public string Marca { get; private set; }
    public string Modelo { get; private set; }
    public int Anio { get; private set; }
    public decimal Precio { get; private set; }
    public string EstadoAprobacion { get; private set; }

    protected Car()
    {
        Marca = string.Empty;
        Modelo = string.Empty;
        Anio = 0;
        Precio = 0;
        EstadoAprobacion = string.Empty;
    }

    public Car(CreateCarCommand command)
    {
        Marca = command.Marca;
        Modelo = command.Modelo;
        Anio = command.Anio;
        Precio = command.Precio;
        EstadoAprobacion = command.EstadoAprobacion;
    }
    
    public void UpdateApprovalStatus(string estadoAprobacion)
    {
        EstadoAprobacion = estadoAprobacion;
    }
}