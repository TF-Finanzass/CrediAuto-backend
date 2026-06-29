using CrediAuto.API.IAM.Domain.Model.Commands;
using CrediAuto.API.IAM.Interfaces.REST.Resources;

namespace CrediAuto.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password, resource.Role);
    }
}
