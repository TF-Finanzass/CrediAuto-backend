using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Schedules.Domain.Model.Commands;
using CrediAuto.API.Schedules.Domain.Repositories;
using CrediAuto.API.Schedules.Domain.Services;
using CrediAuto.API.Shared.Domain.Repositories;

namespace CrediAuto.API.Schedules.Application.Internal.CommandServices;

public class ScheduleCommandService(
    IScheduleRepository scheduleRepository,
    IUnitOfWork unitOfWork)
    : IScheduleCommandService
{
    public async Task<Schedule?> Handle(CreateScheduleCommand command)
    {
        var schedule = new Schedule(command);
        try
        {
            await scheduleRepository.AddAsync(schedule);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating Schedule: {ex.Message}");
            return null;
        }
        return schedule;
    }

    public async Task<bool> Handle(DeleteScheduleCommand command)
    {
        var schedule = await scheduleRepository.FindByIdAsync(command.ScheduleId);
        if (schedule is null) return false;
        try
        {
            scheduleRepository.Remove(schedule);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting Schedule: {ex.Message}");
            return false;
        }
    }
}