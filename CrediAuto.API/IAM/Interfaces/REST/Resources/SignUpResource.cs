using CrediAuto.API.IAM.Domain.Model.Enums;

namespace CrediAuto.API.IAM.Interfaces.REST.Resources;

public record SignUpResource(string Username, string Password, Roles Role);
