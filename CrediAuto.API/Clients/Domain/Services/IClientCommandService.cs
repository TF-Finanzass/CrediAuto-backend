using System.Threading.Tasks;
using CrediAuto.API.Clients.Domain.Model.Aggregates;
using CrediAuto.API.Clients.Domain.Model.Commands;

namespace CrediAuto.API.Clients.Domain.Services;

public interface IClientCommandService
{
    Task<Client?> Handle(CreateClientCommand command);
    Task<bool> Handle(DeleteClientCommand command);
    Task<Client?> Handle(UpdateClientCommand command);
    Task<Client?> Handle(UpdateClientStatusCommand command);
}