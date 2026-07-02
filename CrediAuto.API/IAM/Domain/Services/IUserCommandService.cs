using System.Threading.Tasks;
using CrediAuto.API.IAM.Domain.Model.Aggregates;
using CrediAuto.API.IAM.Domain.Model.Commands;

namespace CrediAuto.API.IAM.Domain.Services;

public interface IUserCommandService
{
    Task<(User user, string token)> Handle(SignInCommand command);
    
    Task Handle(SignUpCommand command);
}