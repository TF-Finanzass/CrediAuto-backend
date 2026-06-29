using CrediAuto.API.Simulations.Domain.Model.Aggregates;
using CrediAuto.API.Shared.Domain.Repositories;


namespace CrediAuto.API.Simulations.Domain.Repositories;

public interface ISimulationRepository : IBaseRepository<Model.Aggregates.Simulation>
{
}