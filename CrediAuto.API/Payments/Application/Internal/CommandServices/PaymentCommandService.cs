using CrediAuto.API.Payments.Domain.Model.Aggregates;
using CrediAuto.API.Payments.Domain.Model.Commands;
using CrediAuto.API.Payments.Domain.Repositories;
using CrediAuto.API.Payments.Domain.Services;
using CrediAuto.API.Shared.Domain.Repositories;

namespace CrediAuto.API.Payments.Application.Internal.CommandServices;

public class PaymentCommandService(
    IPaymentRepository paymentRepository,
    IUnitOfWork unitOfWork)
    : IPaymentCommandService
{
    public async Task<Payment?> Handle(CreatePaymentCommand command)
    {
        var payment = new Payment(command);
        try
        {
            await paymentRepository.AddAsync(payment);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating Payment: {ex.Message}");
            return null;
        }
        return payment;
    }

    public async Task<bool> Handle(DeletePaymentCommand command)
    {
        var payment = await paymentRepository.FindByIdAsync(command.PaymentId);
        if (payment is null) return false;
        try
        {
            paymentRepository.Remove(payment);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting Payment: {ex.Message}");
            return false;
        }
    }
}