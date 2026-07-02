using System.Collections.Generic;
using System.Threading.Tasks;
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

    public async Task<Client?> Handle(GetClientByDocumentNumberQuery query)
        => await clientRepository.FindByDocumentNumberAsync(query.DocumentNumber);

    public async Task<Client?> Handle(GetClientByUserIdQuery query)
        => await clientRepository.FindByUserIdAsync(query.UserId);
    
    public async Task<IEnumerable<Client>> Handle(GetClientsByStatusQuery query)
        => await clientRepository.FindByStatusAsync(query.Status);
}