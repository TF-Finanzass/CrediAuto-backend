using System.Threading.Tasks;
using CrediAuto.API.Simulations.Domain.Model.Aggregates;
using CrediAuto.API.Simulations.Domain.Model.Commands;

namespace CrediAuto.API.Simulations.Domain.Services;

public interface ISimulationCommandService
{
    Task<Model.Aggregates.Simulation?> Handle(CreateSimulationCommand command);
    
    Task<bool> Handle(DeleteSimulationCommand command);
}