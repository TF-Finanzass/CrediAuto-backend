using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Schedules.Domain.Model.Commands;

namespace CrediAuto.API.Schedules.Domain.Services;

public interface IScheduleCommandService
{
    Task<Schedule?> Handle(CreateScheduleCommand command);
    Task<bool> Handle(DeleteScheduleCommand command);
}