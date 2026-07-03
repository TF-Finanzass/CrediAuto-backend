using CrediAuto.API.Cars.Domain.Model.Commands;
using CrediAuto.API.Cars.Domain.Model.ValueObjects;
using CrediAuto.API.Cars.Interfaces.REST.Resources;

namespace CrediAuto.API.Cars.Interfaces.REST.Transform;

public static class CreateCarCommandFromResourceAssembler
{
    public static CreateCarCommand ToCommandFromResource(CreateCarResource resource) =>
        new CreateCarCommand(
            resource.Brand,
            resource.Model,
            resource.Year,
            resource.Price,
            resource.Detail,
            resource.Status ?? CarStatus.Disponible
        );
}