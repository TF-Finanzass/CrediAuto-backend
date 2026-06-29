using CrediAuto.API.Payments.Domain.Model.Commands;
using CrediAuto.API.Payments.Interfaces.REST.Resources;

namespace CrediAuto.API.Payments.Interfaces.REST.Transform;

public static class CreatePaymentCommandFromResourceAssembler
{
    public static CreatePaymentCommand ToCommandFromResource(CreatePaymentResource resource) =>
        new CreatePaymentCommand(
            resource.CronogramaId, 
            resource.Numero, 
            resource.FechaVencimiento,
            resource.Monto, 
            resource.EstadoPago
            );
}