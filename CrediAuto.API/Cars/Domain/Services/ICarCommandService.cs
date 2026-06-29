using CrediAuto.API.Cars.Domain.Model.Aggregates;
using CrediAuto.API.Cars.Domain.Model.Commands;

namespace CrediAuto.API.Cars.Domain.Services;

public interface ICarCommandService
{
    Task<Car?> Handle(CreateCarCommand command);
    Task<bool> Handle(DeleteCarCommand command);
    Task<Car?> Handle(UpdateCarApprovalStatusCommand command);
}