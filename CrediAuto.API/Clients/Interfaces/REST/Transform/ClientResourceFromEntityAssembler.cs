using CrediAuto.API.Clients.Domain.Model.Aggregates;
using CrediAuto.API.Clients.Interfaces.REST.Resources;

namespace CrediAuto.API.Clients.Interfaces.REST.Transform;

public static class ClientResourceFromEntityAssembler
{
    public static ClientResource ToResourceFromEntity(Client entity) =>
        new ClientResource(
            entity.Id, 
            entity.Nombre, 
            entity.Dni, 
            entity.Email,
            entity.Telefono, 
            entity.UserId, 
            entity.CreatedDate, 
            entity.UpdatedDate
            );
}