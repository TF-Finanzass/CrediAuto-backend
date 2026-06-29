namespace CrediAuto.API.Schedules.Interfaces.REST.Resources;

public record ScheduleResource(
    int Id,
    int OperacionId,
    int NumCuotas,
    decimal MontoTotal,
    decimal Tcea,
    DateTimeOffset? Created,
    DateTimeOffset? Updated
    );