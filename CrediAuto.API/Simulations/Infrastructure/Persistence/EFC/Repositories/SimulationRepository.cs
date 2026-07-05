using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using CrediAuto.API.Simulations.Domain.Repositories;

namespace CrediAuto.API.Simulations.Infrastructure.Persistence.EFC.Repositories;

public class SimulationRepository(AppDbContext context)
    : BaseRepository<Domain.Model.Aggregates.Simulation>(context), ISimulationRepository
{
}