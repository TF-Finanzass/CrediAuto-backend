using CrediAuto.API.Cars.Domain.Model.Aggregates;
using CrediAuto.API.Cars.Domain.Model.Queries;
using CrediAuto.API.Cars.Domain.Repositories;
using CrediAuto.API.Cars.Domain.Services;

namespace CrediAuto.API.Cars.Application.Internal.QueryServices;

public class CarQueryService(ICarRepository carRepository)
    : ICarQueryService
{
    public async Task<Car?> Handle(GetCarByIdQuery query)
        => await carRepository.FindByIdAsync(query.Id);

    public async Task<IEnumerable<Car>> Handle(GetAllCarsQuery query)
        => await carRepository.ListAsync();

    public async Task<IEnumerable<Car>> Handle(GetCarsByStatusQuery query)
        => await carRepository.FindByStatusAsync(query.Status);
}