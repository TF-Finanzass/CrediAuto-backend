using CrediAuto.API.IAM.Domain.Model.Enums;

namespace CrediAuto.API.IAM.Domain.Model.Commands;

public record SignUpCommand(string Username, string Password, Roles Role);
