using CrediAuto.API.Simulations.Domain.Model.Aggregates;
using CrediAuto.API.Simulations.Domain.Model.Queries;

namespace CrediAuto.API.Simulations.Domain.Services;

public interface ISimulationQueryService
{
    Task<Model.Aggregates.Simulation?> Handle(GetSimulationByIdQuery query);
    Task<IEnumerable<Model.Aggregates.Simulation>> Handle(GetAllSimulationsQuery query);
}