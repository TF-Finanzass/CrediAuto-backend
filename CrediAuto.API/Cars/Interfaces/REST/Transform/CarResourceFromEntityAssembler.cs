using CrediAuto.API.Cars.Domain.Model.Aggregates;
using CrediAuto.API.Cars.Interfaces.REST.Resources;

namespace CrediAuto.API.Cars.Interfaces.REST.Transform;

public static class CarResourceFromEntityAssembler
{
    public static CarResource ToResourceFromEntity(Car entity) =>
        new CarResource(
            entity.Id,
            entity.Brand,
            entity.Model,
            entity.Year,
            entity.Price,
            entity.FuelType,
            entity.Transmission,
            entity.Detail,
            entity.Status,
            entity.CreatedDate,
            entity.UpdatedDate
        );
}