using CrediAuto.API.Clients.Domain.Model.ValueObjects;

namespace CrediAuto.API.Clients.Interfaces.REST.Resources;

public record ClientResource(
    int Id,
    string FullName,
    string LastName,
    string DocumentNumber,
    string Email,
    string Phone,
    decimal MonthlyIncome,
    int UserId,
    ClientStatus Status,
    DateTimeOffset? Created,
    DateTimeOffset? Updated
);