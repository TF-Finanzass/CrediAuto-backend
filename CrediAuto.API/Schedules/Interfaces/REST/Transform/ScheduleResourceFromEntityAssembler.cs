using CrediAuto.API.Schedules.Domain.Model.Aggregates;
using CrediAuto.API.Schedules.Interfaces.REST.Resources;

namespace CrediAuto.API.Schedules.Interfaces.REST.Transform;

public static class ScheduleResourceFromEntityAssembler
{
    public static ScheduleResource ToResourceFromEntity(Schedule entity) =>
        new ScheduleResource(
            entity.Id, 
            entity.OperacionId, 
            entity.NumCuotas,
            entity.MontoTotal, 
            entity.Tcea, 
            entity.CreatedDate, 
            entity.UpdatedDate
            );
}