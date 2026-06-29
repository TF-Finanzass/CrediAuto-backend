using CrediAuto.API.Schedules.Domain.Model.Commands;
using CrediAuto.API.Schedules.Interfaces.REST.Resources;

namespace CrediAuto.API.Schedules.Interfaces.REST.Transform;

public static class CreateScheduleCommandFromResourceAssembler
{
    public static CreateScheduleCommand ToCommandFromResource(CreateScheduleResource resource) =>
        new CreateScheduleCommand(
            resource.OperacionId, 
            resource.NumCuotas,
            resource.MontoTotal, 
            resource.Tcea
            );
}