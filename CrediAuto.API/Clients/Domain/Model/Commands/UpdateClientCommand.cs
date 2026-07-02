namespace CrediAuto.API.Clients.Domain.Model.Commands;

public record UpdateClientCommand(
    int ClientId,
    string FullName,
    string LastName,
    string Email,
    string Phone
);