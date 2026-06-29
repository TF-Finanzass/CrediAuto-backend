namespace CrediAuto.API.Clients.Domain.Model.Commands;

public record UpdateClientCommand(
    int ClientId,
    string Nombre,
    string Email,
    string Telefono
    );