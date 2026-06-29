using CrediAuto.API.Clients.Domain.Model.Commands;
using CrediAuto.API.Clients.Interfaces.REST.Resources;

namespace CrediAuto.API.Clients.Interfaces.REST.Transform;

public static class CreateClientCommandFromResourceAssembler
{
    public static CreateClientCommand ToCommandFromResource(CreateClientResource resource) =>
        new CreateClientCommand(
            resource.Nombre, 
            resource.Dni, 
            resource.Email,
            resource.Telefono, 
            resource.UserId
            );
}