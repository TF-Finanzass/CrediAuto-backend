using CrediAuto.API.Cars.Domain.Model.Aggregates;
using CrediAuto.API.Cars.Domain.Model.Commands;
using CrediAuto.API.Cars.Domain.Repositories;
using CrediAuto.API.Cars.Domain.Services;
using CrediAuto.API.Shared.Domain.Repositories;

namespace CrediAuto.API.Cars.Application.Internal.CommandServices;

public class CarCommandService(
    ICarRepository carRepository,
    IUnitOfWork unitOfWork)
    : ICarCommandService
{
    public async Task<Car?> Handle(CreateCarCommand command)
    {
        var car = new Car(command);
        try
        {
            await carRepository.AddAsync(car);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating Car: {ex.Message}");
            return null;
        }
        return car;
    }

    public async Task<bool> Handle(DeleteCarCommand command)
    {
        var car = await carRepository.FindByIdAsync(command.CarId);
        if (car is null) return false;
        try
        {
            carRepository.Remove(car);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting Car: {ex.Message}");
            return false;
        }
    }

    public async Task<Car?> Handle(UpdateCarStatusCommand command)
    {
        var car = await carRepository.FindByIdAsync(command.CarId);
        if (car is null) return null;
        try
        {
            car.UpdateStatus(command.Status);
            carRepository.Update(car);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating Car status: {ex.Message}");
            return null;
        }
        return car;
    }
}