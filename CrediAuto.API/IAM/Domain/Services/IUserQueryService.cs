using CrediAuto.API.IAM.Domain.Model.Aggregates;
using CrediAuto.API.IAM.Domain.Model.Queries;

namespace CrediAuto.API.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    
    Task<User?> Handle(GetUserByUsernameQuery query);
}