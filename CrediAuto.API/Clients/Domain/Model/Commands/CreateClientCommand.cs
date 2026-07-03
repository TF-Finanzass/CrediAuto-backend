using CrediAuto.API.Clients.Domain.Model.ValueObjects;

namespace CrediAuto.API.Clients.Domain.Model.Commands;

public record CreateClientCommand(
    string FullName,
    string LastName,
    string DocumentNumber,
    string Email,
    string Phone,
    decimal MonthlyIncome,
    int UserId,
    ClientStatus Status = ClientStatus.Aprobado
);