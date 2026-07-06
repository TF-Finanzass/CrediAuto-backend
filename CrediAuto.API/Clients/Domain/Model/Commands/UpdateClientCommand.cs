using CrediAuto.API.Clients.Domain.Model.ValueObjects;

namespace CrediAuto.API.Clients.Domain.Model.Commands;

public record UpdateClientCommand(
    int ClientId,
    string FullName,
    string LastName,
    string DocumentNumber,
    string Email,
    string Phone,
    decimal MonthlyIncome,
    ClientStatus Status
);