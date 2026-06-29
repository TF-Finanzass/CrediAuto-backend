using CrediAuto.API.IAM.Domain.Model.Enums;

namespace CrediAuto.API.IAM.Interfaces.REST.Resources;

public record UserResource(int Id, string Username, Roles Role);
