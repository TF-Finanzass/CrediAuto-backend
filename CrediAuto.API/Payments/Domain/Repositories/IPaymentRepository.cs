using CrediAuto.API.Payments.Domain.Model.Aggregates;
using CrediAuto.API.Shared.Domain.Repositories;

namespace CrediAuto.API.Payments.Domain.Repositories;

public interface IPaymentRepository : IBaseRepository<Payment>
{
    Task<IEnumerable<Payment>> FindByCronogramaIdAsync(int cronogramaId);
}