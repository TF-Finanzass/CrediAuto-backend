namespace CrediAuto.API.Schedules.Domain.Model.Commands;

public record CreateScheduleCommand(
    int OperacionId,
    int NumCuotas,
    decimal MontoTotal,
    decimal Tcea
    );