using CrediAuto.API.Clients.Domain.Model.ValueObjects;

namespace CrediAuto.API.Clients.Domain.Model.Queries;

public record GetClientsByStatusQuery(
    ClientStatus Status
);