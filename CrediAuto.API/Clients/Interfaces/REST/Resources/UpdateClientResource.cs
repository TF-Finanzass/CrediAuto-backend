using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Clients.Interfaces.REST.Resources;

public record UpdateClientResource(
    [Required] string Nombre,
    [Required] string Email,
    [Required] string Telefono
    );