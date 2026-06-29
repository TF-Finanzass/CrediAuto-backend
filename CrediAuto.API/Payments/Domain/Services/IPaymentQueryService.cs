using CrediAuto.API.Payments.Domain.Model.Aggregates;
using CrediAuto.API.Payments.Domain.Model.Queries;

namespace CrediAuto.API.Payments.Domain.Services;

public interface IPaymentQueryService
{
    Task<Payment?> Handle(GetPaymentByIdQuery query);
    Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query);
    Task<IEnumerable<Payment>> Handle(GetPaymentsByCronogramaIdQuery query);
}