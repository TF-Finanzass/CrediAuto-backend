using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Cars.Interfaces.REST.Resources;

public record CreateCarResource(
    [Required] string Marca,
    [Required] string Modelo,
    [Required] int Anio,
    [Required] decimal Precio,
    [Required] string EstadoAprobacion
    );