using CrediAuto.API.Simulations.Domain.Model.Queries;
using CrediAuto.API.Simulations.Domain.Repositories;
using CrediAuto.API.Simulations.Domain.Services;

namespace CrediAuto.API.Simulations.Application.Internal.QueryServices;

public class SimulationQueryService(ISimulationRepository simulationRepository)
    : ISimulationQueryService
{
    public async Task<Domain.Model.Aggregates.Simulation?> Handle(GetSimulationByIdQuery query)
        => await simulationRepository.FindByIdAsync(query.Id);

    public async Task<IEnumerable<Domain.Model.Aggregates.Simulation>> Handle(GetAllSimulationsQuery query)
        => await simulationRepository.ListAsync();
}