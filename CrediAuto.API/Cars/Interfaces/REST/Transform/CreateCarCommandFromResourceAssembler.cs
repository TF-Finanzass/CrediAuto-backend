using CrediAuto.API.Cars.Domain.Model.Commands;
using CrediAuto.API.Cars.Interfaces.REST.Resources;

namespace CrediAuto.API.Cars.Interfaces.REST.Transform;

public static class CreateCarCommandFromResourceAssembler
{
    public static CreateCarCommand ToCommandFromResource(CreateCarResource resource) =>
        new CreateCarCommand(
            resource.Marca, 
            resource.Modelo, 
            resource.Anio,
            resource.Precio, 
            resource.EstadoAprobacion
            );
}