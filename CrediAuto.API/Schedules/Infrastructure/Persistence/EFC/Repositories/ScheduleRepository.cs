using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Schedules.Domain.Repositories;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Schedules.Infrastructure.Persistence.EFC.Repositories;

public class ScheduleRepository(AppDbContext context)
    : BaseRepository<Schedule>(context), IScheduleRepository
{
    public async Task<IEnumerable<Schedule>> FindByOperacionIdAsync(int operacionId)
        => await Context.Set<Schedule>().Where(s => s.OperacionId == operacionId).ToListAsync();
}