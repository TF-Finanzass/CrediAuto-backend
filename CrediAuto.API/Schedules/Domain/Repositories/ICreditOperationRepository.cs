using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Shared.Domain.Repositories;

namespace CrediAuto.API.Schedules.Domain.Repositories;

public interface ICreditOperationRepository : IBaseRepository<CreditOperation>
{
    Task<CreditOperation?> FindByIdWithScheduleAsync(int id);
    Task<IEnumerable<CreditOperation>> ListWithScheduleAsync();
    Task<IEnumerable<CreditOperation>> FindByClientIdAsync(int clientId);
    Task<IEnumerable<CreditOperation>> FindByCarIdAsync(int carId);
}