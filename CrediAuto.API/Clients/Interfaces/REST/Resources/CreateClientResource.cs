using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Clients.Interfaces.REST.Resources;

public record CreateClientResource(
    [Required] string Nombre,
    [Required] string Dni,
    [Required] string Email,
    [Required] string Telefono,
    [Required] int UserId
    );