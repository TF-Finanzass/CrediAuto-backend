using CrediAuto.API.Clients.Domain.Model.Aggregates;
using CrediAuto.API.Clients.Interfaces.REST.Resources;

namespace CrediAuto.API.Clients.Interfaces.REST.Transform;

public static class ClientResourceFromEntityAssembler
{
    public static ClientResource ToResourceFromEntity(Client entity) =>
        new ClientResource(
            entity.Id,
            entity.FullName,
            entity.LastName,
            entity.DocumentNumber,
            entity.Email,
            entity.Phone,
            entity.MonthlyIncome,
            entity.UserId,
            entity.Status,
            entity.CreatedDate,
            entity.UpdatedDate
        );
}