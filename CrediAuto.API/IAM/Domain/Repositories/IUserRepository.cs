using CrediAuto.API.IAM.Domain.Model.Aggregates;
using CrediAuto.API.Shared.Domain.Repositories;

namespace CrediAuto.API.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    
    bool ExistsByUsername(string username);
}