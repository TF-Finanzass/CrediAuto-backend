using CrediAuto.API.IAM.Domain.Model.Enums;

namespace CrediAuto.API.IAM.Interfaces.REST.Resources;

public record AuthenticatedUserResource(int Id, string Username, Roles Role, string Token);
