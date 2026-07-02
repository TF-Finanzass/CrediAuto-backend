using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Clients.Interfaces.REST.Resources;

public record UpdateClientResource(
    [Required] string FullName,
    [Required] string LastName,
    [Required] string Email,
    [Required] string Phone
);