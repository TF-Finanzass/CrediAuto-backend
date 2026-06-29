using CrediAuto.API.Clients.Domain.Model.Aggregates;
using CrediAuto.API.Clients.Domain.Model.Queries;

namespace CrediAuto.API.Clients.Domain.Services;

public interface IClientQueryService
{
    Task<Client?> Handle(GetClientByIdQuery query);
    Task<IEnumerable<Client>> Handle(GetAllClientsQuery query);
    Task<Client?> Handle(GetClientByDniQuery query);
    Task<Client?> Handle(GetClientByUserIdQuery query);
}