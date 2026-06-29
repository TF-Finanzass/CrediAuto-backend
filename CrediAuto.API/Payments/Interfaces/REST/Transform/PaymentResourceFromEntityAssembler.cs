using CrediAuto.API.Payments.Domain.Model.Aggregates;
using CrediAuto.API.Payments.Interfaces.REST.Resources;

namespace CrediAuto.API.Payments.Interfaces.REST.Transform;

public static class PaymentResourceFromEntityAssembler
{
    public static PaymentResource ToResourceFromEntity(Payment entity) =>
        new PaymentResource(
            entity.Id, 
            entity.CronogramaId, 
            entity.Numero, 
            entity.FechaVencimiento,
            entity.Monto, 
            entity.EstadoPago, 
            entity.CreatedDate, 
            entity.UpdatedDate
            );
}