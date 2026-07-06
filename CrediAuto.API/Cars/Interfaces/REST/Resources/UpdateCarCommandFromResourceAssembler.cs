using CrediAuto.API.Cars.Domain.Model.Commands;
using CrediAuto.API.Cars.Interfaces.REST.Resources;

namespace CrediAuto.API.Cars.Interfaces.REST.Transform;

public static class UpdateCarCommandFromResourceAssembler
{
    public static UpdateCarCommand ToCommandFromResource(int id, UpdateCarResource resource) =>
        new UpdateCarCommand(
            id,
            resource.Brand,
            resource.Model,
            resource.Year,
            resource.Price,
            resource.Currency,
            resource.Detail,
            resource.Status
        );
}