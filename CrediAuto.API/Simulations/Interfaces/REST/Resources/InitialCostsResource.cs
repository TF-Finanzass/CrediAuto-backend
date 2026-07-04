using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Simulations.Interfaces.REST.Resources;

public record SimulationInitialCostsResource(
    [Required] decimal Notarial,
    [Required] decimal Registration,
    [Required] decimal Appraisal,
    [Required] decimal StudyFee,
    [Required] decimal ActivationFee
);