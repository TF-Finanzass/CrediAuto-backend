namespace CrediAuto.API.Simulations.Domain.Model.ValueObjects;

public record InitialCosts(
    decimal Notarial,
    decimal Registration,
    decimal Appraisal,
    decimal StudyFee,
    decimal ActivationFee
);