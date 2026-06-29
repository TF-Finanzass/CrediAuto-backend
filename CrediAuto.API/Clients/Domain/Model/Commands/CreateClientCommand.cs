namespace CrediAuto.API.Clients.Domain.Model.Commands;

public record CreateClientCommand(
    string Nombre,
    string Dni,
    string Email,
    string Telefono,
    int UserId
    );