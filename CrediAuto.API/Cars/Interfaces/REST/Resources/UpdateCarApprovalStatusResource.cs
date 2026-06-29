using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Cars.Interfaces.REST.Resources;

public record UpdateCarApprovalStatusResource(
    [Required] string EstadoAprobacion
    );
