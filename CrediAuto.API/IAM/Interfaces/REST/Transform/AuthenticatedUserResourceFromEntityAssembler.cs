using CrediAuto.API.IAM.Domain.Model.Aggregates;
using CrediAuto.API.IAM.Interfaces.REST.Resources;

namespace CrediAuto.API.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, user.Role, token);
    }
}
