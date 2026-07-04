using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Schedules.Interfaces.REST.Resources;

public record InitialCostsResource(
    [Required] decimal Notarial,
    [Required] decimal Registration,
    [Required] decimal Appraisal,
    [Required] decimal StudyFee,
    [Required] decimal ActivationFee
);