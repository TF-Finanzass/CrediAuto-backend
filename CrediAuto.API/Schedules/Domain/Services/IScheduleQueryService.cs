using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Schedules.Domain.Model.Queries;

namespace CrediAuto.API.Schedules.Domain.Services;

public interface IScheduleQueryService
{
    Task<Schedule?> Handle(GetScheduleByIdQuery query);
    Task<IEnumerable<Schedule>> Handle(GetAllSchedulesQuery query);
    Task<IEnumerable<Schedule>> Handle(GetSchedulesByOperacionIdQuery query);
}