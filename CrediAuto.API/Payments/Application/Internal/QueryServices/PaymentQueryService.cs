using CrediAuto.API.Payments.Domain.Model.Aggregates;
using CrediAuto.API.Payments.Domain.Model.Queries;
using CrediAuto.API.Payments.Domain.Repositories;
using CrediAuto.API.Payments.Domain.Services;

namespace CrediAuto.API.Payments.Application.Internal.QueryServices;

public class PaymentQueryService(IPaymentRepository paymentRepository)
    : IPaymentQueryService
{
    public async Task<Payment?> Handle(GetPaymentByIdQuery query)
        => await paymentRepository.FindByIdAsync(query.Id);

    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query)
        => await paymentRepository.ListAsync();

    public async Task<IEnumerable<Payment>> Handle(GetPaymentsByCronogramaIdQuery query)
        => await paymentRepository.FindByCronogramaIdAsync(query.CronogramaId);
}