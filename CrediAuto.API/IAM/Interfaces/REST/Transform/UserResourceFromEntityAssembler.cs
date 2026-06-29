using CrediAuto.API.IAM.Domain.Model.Aggregates;
using CrediAuto.API.IAM.Interfaces.REST.Resources;

namespace CrediAuto.API.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username, user.Role);
    }
}
