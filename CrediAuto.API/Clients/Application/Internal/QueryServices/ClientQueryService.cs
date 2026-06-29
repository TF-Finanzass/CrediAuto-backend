using CrediAuto.API.Clients.Domain.Model.Aggregates;
using CrediAuto.API.Clients.Domain.Model.Queries;
using CrediAuto.API.Clients.Domain.Repositories;
using CrediAuto.API.Clients.Domain.Services;

namespace CrediAuto.API.Clients.Application.Internal.QueryServices;

public class ClientQueryService(IClientRepository clientRepository)
    : IClientQueryService
{
    public async Task<Client?> Handle(GetClientByIdQuery query)
        => await clientRepository.FindByIdAsync(query.Id);

    public async Task<IEnumerable<Client>> Handle(GetAllClientsQuery query)
        => await clientRepository.ListAsync();

    public async Task<Client?> Handle(GetClientByDniQuery query)
        => await clientRepository.FindByDniAsync(query.Dni);

    public async Task<Client?> Handle(GetClientByUserIdQuery query)
        => await clientRepository.FindByUserIdAsync(query.UserId);
}