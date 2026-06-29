namespace CrediAuto.API.Payments.Interfaces.REST.Resources;

public record PaymentResource(
    int Id,
    int CronogramaId,
    int Numero,
    DateTimeOffset FechaVencimiento,
    decimal Monto,
    string EstadoPago,
    DateTimeOffset? Created,
    DateTimeOffset? Updated
    );