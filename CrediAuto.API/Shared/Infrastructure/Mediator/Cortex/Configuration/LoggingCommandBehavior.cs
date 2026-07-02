using System.Threading;
using System.Threading.Tasks;
using Cortex.Mediator.Commands;

namespace CrediAuto.API.Shared.Infrastructure.Mediator.Cortex.Configuration;

public class LoggingCommandBehavior<TCommand> 
    : ICommandPipelineBehavior<TCommand> where TCommand : ICommand
{
    public async Task Handle(
        TCommand command, 
        CommandHandlerDelegate next,
        CancellationToken ct)
    {
        await next();
    }
}