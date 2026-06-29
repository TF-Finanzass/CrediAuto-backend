using System.ComponentModel.DataAnnotations;

namespace CrediAuto.API.Schedules.Interfaces.REST.Resources;

public record CreateScheduleResource(
    [Required] int OperacionId,
    [Required] int NumCuotas,
    [Required] decimal MontoTotal,
    [Required] decimal Tcea
    );