namespace CrediAuto.API.Payments.Domain.Model.Commands;

public record CreatePaymentCommand(
    int CronogramaId,
    int Numero,
    DateTimeOffset FechaVencimiento,
    decimal Monto,
    string EstadoPago
    );