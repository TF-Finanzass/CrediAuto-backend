using System.Threading.Tasks;
using CrediAuto.API.IAM.Domain.Model.Aggregates;

namespace CrediAuto.API.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    
    Task<int?> ValidateToken(string token);
}