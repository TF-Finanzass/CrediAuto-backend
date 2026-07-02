using CrediAuto.API.Clients.Domain.Model.ValueObjects;

namespace CrediAuto.API.Clients.Domain.Model.Commands;

public record UpdateClientStatusCommand(
    int ClientId,
    ClientStatus Status
);