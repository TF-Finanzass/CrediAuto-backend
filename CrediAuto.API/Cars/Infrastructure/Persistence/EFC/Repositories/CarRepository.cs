using CrediAuto.API.Cars.Domain.Model.Aggregates;
using CrediAuto.API.Cars.Domain.Repositories;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrediAuto.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrediAuto.API.Cars.Infrastructure.Persistence.EFC.Repositories;

public class CarRepository(AppDbContext context)
    : BaseRepository<Car>(context), ICarRepository
{
    public async Task<IEnumerable<Car>> FindByEstadoAprobacionAsync(string estadoAprobacion)
        => await Context.Set<Car>().Where(c => c.EstadoAprobacion == estadoAprobacion).ToListAsync();
}