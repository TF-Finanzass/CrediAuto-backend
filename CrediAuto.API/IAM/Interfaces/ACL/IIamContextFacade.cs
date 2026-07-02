using System.Threading.Tasks;
using CrediAuto.API.IAM.Domain.Model.Enums;

namespace CrediAuto.API.IAM.Interfaces.ACL;

public interface IIamContextFacade
{
    Task<int> CreateUser(string username, string password, Roles role);
    Task<int> FetchUserIdByUsername(string username);
    Task<string> FetchUsernameByUserId(int userId);
}
