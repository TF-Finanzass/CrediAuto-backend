using CrediAuto.API.Cars.Domain.Model.Aggregates;
using CrediAuto.API.Cars.Interfaces.REST.Resources;

namespace CrediAuto.API.Cars.Interfaces.REST.Transform;

public static class CarResourceFromEntityAssembler
{
    public static CarResource ToResourceFromEntity(Car entity) =>
        new CarResource(
            entity.Id, 
            entity.Marca, 
            entity.Modelo, 
            entity.Anio,
            entity.Precio, 
            entity.EstadoAprobacion, 
            entity.CreatedDate, 
            entity.UpdatedDate
            );
}