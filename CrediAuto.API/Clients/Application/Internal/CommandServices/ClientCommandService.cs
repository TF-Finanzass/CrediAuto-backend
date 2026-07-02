using System;
using System.Threading.Tasks;
using CrediAuto.API.Clients.Domain.Model.Aggregates;
using CrediAuto.API.Clients.Domain.Model.Commands;
using CrediAuto.API.Clients.Domain.Repositories;
using CrediAuto.API.Clients.Domain.Services;
using CrediAuto.API.Shared.Domain.Repositories;

namespace CrediAuto.API.Clients.Application.Internal.CommandServices;

public class ClientCommandService(
    IClientRepository clientRepository,
    IUnitOfWork unitOfWork)
    : IClientCommandService
{
    public async Task<Client?> Handle(CreateClientCommand command)
    {
        var existing = await clientRepository.FindByDocumentNumberAsync(command.DocumentNumber);
        if (existing is not null) return null;

        var client = new Client(command);
        try
        {
            await clientRepository.AddAsync(client);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating Client: {ex.Message}");
            return null;
        }
        return client;
    }

    public async Task<bool> Handle(DeleteClientCommand command)
    {
        var client = await clientRepository.FindByIdAsync(command.ClientId);
        if (client is null) return false;
        try
        {
            clientRepository.Remove(client);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting Client: {ex.Message}");
            return false;
        }
    }
    
    public async Task<Client?> Handle(UpdateClientCommand command)
    {
        var client = await clientRepository.FindByIdAsync(command.ClientId);
        if (client is null) return null;
        try
        {
            client.UpdateContactInfo(command.FullName, command.LastName, command.Email, command.Phone);
            clientRepository.Update(client);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating Client: {ex.Message}");
            return null;
        }
        return client;
    }

    public async Task<Client?> Handle(UpdateClientStatusCommand command)
    {
        var client = await clientRepository.FindByIdAsync(command.ClientId);
        if (client is null) return null;
        try
        {
            client.UpdateStatus(command.Status);
            clientRepository.Update(client);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating Client status: {ex.Message}");
            return null;
        }
        return client;
    }
}