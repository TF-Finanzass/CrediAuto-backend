using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Schedules.Domain.Model.Commands;
using CrediAuto.API.Schedules.Domain.Repositories;
using CrediAuto.API.Schedules.Domain.Services;
using CrediAuto.API.Shared.Domain.Repositories;

namespace CrediAuto.API.Schedules.Application.Internal.CommandServices;

public class CreditOperationCommandService(
    ICreditOperationRepository creditOperationRepository,
    IUnitOfWork unitOfWork)
    : ICreditOperationCommandService
{
    public async Task<CreditOperation?> Handle(CreateCreditOperationCommand command)
    {
        var operation = new CreditOperation(command);
        try
        {
            await creditOperationRepository.AddAsync(operation);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating CreditOperation: {ex.Message}");
            return null;
        }
        return operation;
    }

    public async Task<bool> Handle(DeleteCreditOperationCommand command)
    {
        var operation = await creditOperationRepository.FindByIdAsync(command.CreditOperationId);
        if (operation is null) return false;
        try
        {
            creditOperationRepository.Remove(operation);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting CreditOperation: {ex.Message}");
            return false;
        }
    }
}