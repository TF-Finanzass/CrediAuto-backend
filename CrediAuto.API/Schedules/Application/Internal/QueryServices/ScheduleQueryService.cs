using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Schedules.Domain.Model.Queries;
using CrediAuto.API.Schedules.Domain.Repositories;
using CrediAuto.API.Schedules.Domain.Services;

namespace CrediAuto.API.Schedules.Application.Internal.QueryServices;

public class ScheduleQueryService(IScheduleRepository scheduleRepository)
    : IScheduleQueryService
{
    public async Task<Schedule?> Handle(GetScheduleByIdQuery query)
        => await scheduleRepository.FindByIdAsync(query.Id);

    public async Task<IEnumerable<Schedule>> Handle(GetAllSchedulesQuery query)
        => await scheduleRepository.ListAsync();

    public async Task<IEnumerable<Schedule>> Handle(GetSchedulesByOperacionIdQuery query)
        => await scheduleRepository.FindByOperacionIdAsync(query.OperacionId);
}