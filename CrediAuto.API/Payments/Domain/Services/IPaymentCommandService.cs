using CrediAuto.API.Payments.Domain.Model.Aggregates;
using CrediAuto.API.Payments.Domain.Model.Commands;

namespace CrediAuto.API.Payments.Domain.Services;

public interface IPaymentCommandService
{
    Task<Payment?> Handle(CreatePaymentCommand command);
    Task<bool> Handle(DeletePaymentCommand command);
}