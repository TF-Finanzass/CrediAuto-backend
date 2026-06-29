using CrediAuto.API.Payments.Domain.Model.Commands;

namespace CrediAuto.API.Payments.Domain.Model.Aggregates;

public partial class Payment : PaymentAudit
{
    public int Id { get; }
    public int CronogramaId { get; private set; }
    public int Numero { get; private set; }
    public DateTimeOffset FechaVencimiento { get; private set; }
    public decimal Monto { get; private set; }
    public string EstadoPago { get; private set; }

    protected Payment()
    {
        CronogramaId = 0;
        Numero = 0;
        FechaVencimiento = DateTimeOffset.UtcNow;
        Monto = 0;
        EstadoPago = string.Empty;
    }

    public Payment(CreatePaymentCommand command)
    {
        CronogramaId = command.CronogramaId;
        Numero = command.Numero;
        FechaVencimiento = command.FechaVencimiento;
        Monto = command.Monto;
        EstadoPago = command.EstadoPago;
    }
}