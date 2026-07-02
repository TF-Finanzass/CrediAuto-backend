using CrediAuto.API.Cars.Domain.Model.ValueObjects;

namespace CrediAuto.API.Cars.Domain.Model.Queries;

public record GetCarsByStatusQuery(
    CarStatus Status
);