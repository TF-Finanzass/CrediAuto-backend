using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Schedules.Domain.Repositories;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Schedules.Infrastructure.Persistence.EFC.Repositories;

public class CreditOperationRepository(AppDbContext context)
    : BaseRepository<CreditOperation>(context), ICreditOperationRepository
{
    public async Task<CreditOperation?> FindByIdWithScheduleAsync(int id)
        => await Context.Set<CreditOperation>()
            .Include(o => o.Schedule)
            .FirstOrDefaultAsync(o => o.Id == id);

    public async Task<IEnumerable<CreditOperation>> ListWithScheduleAsync()
        => await Context.Set<CreditOperation>()
            .Include(o => o.Schedule)
            .ToListAsync();

    public async Task<IEnumerable<CreditOperation>> FindByClientIdAsync(int clientId)
        => await Context.Set<CreditOperation>()
            .Include(o => o.Schedule)
            .Where(o => o.ClientId == clientId)
            .ToListAsync();

    public async Task<IEnumerable<CreditOperation>> FindByCarIdAsync(int carId)
        => await Context.Set<CreditOperation>()
            .Include(o => o.Schedule)
            .Where(o => o.CarId == carId)
            .ToListAsync();
}