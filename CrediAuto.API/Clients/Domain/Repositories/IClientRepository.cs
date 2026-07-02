using System.Collections.Generic;
using System.Threading.Tasks;
using CrediAuto.API.Clients.Domain.Model.Aggregates;
using CrediAuto.API.Clients.Domain.Model.ValueObjects;
using CrediAuto.API.Shared.Domain.Repositories;

namespace CrediAuto.API.Clients.Domain.Repositories;

public interface IClientRepository : IBaseRepository<Client>
{
    Task<Client?> FindByDocumentNumberAsync(string documentNumber);
    Task<Client?> FindByUserIdAsync(int userId);
    Task<IEnumerable<Client>> FindByStatusAsync(ClientStatus status);
}