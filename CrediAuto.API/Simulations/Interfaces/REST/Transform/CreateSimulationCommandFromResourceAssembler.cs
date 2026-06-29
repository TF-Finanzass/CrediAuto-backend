using CrediAuto.API.Simulations.Domain.Model.Commands;
using CrediAuto.API.Simulations.Interfaces.REST.Resources;

namespace CrediAuto.API.Simulations.Interfaces.REST.Transform;

public static class CreateSimulationCommandFromResourceAssembler
{
    public static CreateSimulationCommand ToCommandFromResource(CreateSimulationResource resource) =>
        new CreateSimulationCommand(resource.Monto, resource.TasaTea, resource.NumCuotas,
            resource.MontoCuota, resource.Fecha);
}