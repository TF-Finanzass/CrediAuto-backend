using CrediAuto.API.Shared.Domain.Repositories;
using CrediAuto.API.Simulations.Domain.Model.Aggregates;
using CrediAuto.API.Simulations.Domain.Model.Commands;
using CrediAuto.API.Simulations.Domain.Repositories;
using CrediAuto.API.Simulations.Domain.Services;

namespace CrediAuto.API.Simulations.Application.Internal.CommandServices;

public class SimulationCommandService(
    ISimulationRepository simulationRepository,
    IUnitOfWork unitOfWork)
    : ISimulationCommandService
{
    public async Task<Domain.Model.Aggregates.Simulation?> Handle(CreateSimulationCommand command)
    {
        var simulation = new Domain.Model.Aggregates.Simulation(command);
        try
        {
            await simulationRepository.AddAsync(simulation);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating Simulation: {ex.Message}");
            return null;
        }
        return simulation;
    }

    public async Task<bool> Handle(DeleteSimulationCommand command)
    {
        var simulation = await simulationRepository.FindByIdAsync(command.SimulationId);
        if (simulation is null) return false;
        try
        {
            simulationRepository.Remove(simulation);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting Simulation: {ex.Message}");
            return false;
        }
    }
}