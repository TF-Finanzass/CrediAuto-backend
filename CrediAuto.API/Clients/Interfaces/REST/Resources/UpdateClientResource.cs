using System.ComponentModel.DataAnnotations;
using CrediAuto.API.Clients.Domain.Model.ValueObjects;

namespace CrediAuto.API.Clients.Interfaces.REST.Resources;

public record UpdateClientResource(
    [Required] string FullName,
    [Required] string LastName,
    [Required] string DocumentNumber,
    [Required] string Email,
    [Required] string Phone,
    [Required] decimal MonthlyIncome,
    [Required] ClientStatus Status
);