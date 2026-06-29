using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Shared.Domain.Repositories;

namespace CrediAuto.API.Schedules.Domain.Repositories;

public interface IScheduleRepository : IBaseRepository<Schedule>
{
    Task<IEnumerable<Schedule>> FindByOperacionIdAsync(int operacionId);
}