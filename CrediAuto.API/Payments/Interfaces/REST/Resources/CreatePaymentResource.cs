using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Payments.Interfaces.REST.Resources;

public record CreatePaymentResource(
    [Required] int CronogramaId,
    [Required] int Numero,
    [Required] DateTimeOffset FechaVencimiento,
    [Required] decimal Monto,
    [Required] string EstadoPago
    );