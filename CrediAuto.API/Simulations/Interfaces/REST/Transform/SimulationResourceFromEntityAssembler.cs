using CrediAuto.API.Simulations.Domain.Model.Aggregates;
using CrediAuto.API.Simulations.Interfaces.REST.Resources;

namespace CrediAuto.API.Simulations.Interfaces.REST.Transform;

public static class SimulationResourceFromEntityAssembler
{
    public static SimulationResource ToResourceFromEntity(Domain.Model.Aggregates.Simulation entity) =>
        new SimulationResource(
            entity.Id, 
            entity.Monto, 
            entity.TasaTea, 
            entity.NumCuotas,
            entity.MontoCuota, 
            entity.Fecha, 
            entity.CreatedDate, 
            entity.UpdatedDate
            );
}