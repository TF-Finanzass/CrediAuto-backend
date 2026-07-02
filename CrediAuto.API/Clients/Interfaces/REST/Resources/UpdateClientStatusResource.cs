using System.ComponentModel.DataAnnotations;
using CrediAuto.API.Clients.Domain.Model.ValueObjects;

namespace CrediAuto.API.Clients.Interfaces.REST.Resources;

public record UpdateClientStatusResource(
    [Required] ClientStatus Status
);