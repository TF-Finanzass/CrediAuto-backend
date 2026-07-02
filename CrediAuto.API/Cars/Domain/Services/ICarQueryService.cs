using System.Collections.Generic;
using System.Threading.Tasks;
using CrediAuto.API.Cars.Domain.Model.Aggregates;
using CrediAuto.API.Cars.Domain.Model.Queries;

namespace CrediAuto.API.Cars.Domain.Services;

public interface ICarQueryService
{
    Task<Car?> Handle(GetCarByIdQuery query);
    Task<IEnumerable<Car>> Handle(GetAllCarsQuery query);
    Task<IEnumerable<Car>> Handle(GetCarsByStatusQuery query);
}