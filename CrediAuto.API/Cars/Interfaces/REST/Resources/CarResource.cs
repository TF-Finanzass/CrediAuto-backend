namespace CrediAuto.API.Cars.Interfaces.REST.Resources;

public record CarResource(
    int Id,
    string Marca,
    string Modelo,
    int Anio,
    decimal Precio,
    string EstadoAprobacion,
    DateTimeOffset? Created,
    DateTimeOffset? Updated
    );