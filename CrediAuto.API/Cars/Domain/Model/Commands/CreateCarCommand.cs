namespace CrediAuto.API.Cars.Domain.Model.Commands;

public record CreateCarCommand(
    string Marca,
    string Modelo,
    int Anio,
    decimal Precio,
    string EstadoAprobacion
    );