namespace CrediAuto.API.Clients.Interfaces.REST.Resources;

public record ClientResource(
    int Id,
    string Nombre,
    string Dni,
    string Email,
    string Telefono,
    int UserId,
    DateTimeOffset? Created,
    DateTimeOffset? Updated
    );