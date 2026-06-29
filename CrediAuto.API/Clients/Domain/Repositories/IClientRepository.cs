using CrediAuto.API.Clients.Domain.Model.Aggregates;
using CrediAuto.API.Shared.Domain.Repositories;

namespace CrediAuto.API.Clients.Domain.Repositories;

public interface IClientRepository : IBaseRepository<Client>
{
    Task<Client?> FindByDniAsync(string dni);
    Task<Client?> FindByUserIdAsync(int userId);
}