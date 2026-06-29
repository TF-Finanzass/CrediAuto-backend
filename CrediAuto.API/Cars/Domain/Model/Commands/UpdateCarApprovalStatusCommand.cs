namespace CrediAuto.API.Cars.Domain.Model.Commands;

public record UpdateCarApprovalStatusCommand(
    int CarId, string EstadoAprobacion
    );