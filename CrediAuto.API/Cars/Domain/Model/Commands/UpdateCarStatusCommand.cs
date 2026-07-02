using CrediAuto.API.Cars.Domain.Model.ValueObjects;

namespace CrediAuto.API.Cars.Domain.Model.Commands;

public record UpdateCarStatusCommand(
    int CarId,
    CarStatus Status
);