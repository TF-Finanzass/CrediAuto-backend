using CrediAuto.API.Cars.Domain.Model.Aggregates;
using CrediAuto.API.Shared.Domain.Repositories;

namespace CrediAuto.API.Cars.Domain.Repositories;

public interface ICarRepository : IBaseRepository<Car>
{
    Task<IEnumerable<Car>> FindByEstadoAprobacionAsync(string estadoAprobacion);
}