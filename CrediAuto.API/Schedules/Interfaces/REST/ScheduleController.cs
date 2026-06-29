using System.Net.Mime;
using CrediAuto.API.Schedules.Domain.Model.Commands;
using CrediAuto.API.Schedules.Domain.Model.Queries;
using CrediAuto.API.Schedules.Domain.Services;
using CrediAuto.API.Schedules.Interfaces.REST.Resources;
using CrediAuto.API.Schedules.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrediAuto.API.Schedules.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Schedule")]
public class ScheduleController(
    IScheduleCommandService scheduleCommandService,
    IScheduleQueryService scheduleQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Schedule", OperationId = "CreateSchedule")]
    [SwaggerResponse(201, "Created schedule", typeof(ScheduleResource))]
    [SwaggerResponse(400, "The schedule was not created")]
    public async Task<IActionResult> CreateSchedule([FromBody] CreateScheduleResource resource)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var command = CreateScheduleCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await scheduleCommandService.Handle(command);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetScheduleById), new { id = result.Id },
            ScheduleResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Get a Schedule by Id", OperationId = "GetScheduleById")]
    [SwaggerResponse(200, "The schedule was found", typeof(ScheduleResource))]
    [SwaggerResponse(404, "Schedule not found")]
    public async Task<IActionResult> GetScheduleById(int id)
    {
        var result = await scheduleQueryService.Handle(new GetScheduleByIdQuery(id));
        if (result is null) return NotFound();
        return Ok(ScheduleResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all Schedules", OperationId = "GetAllSchedules")]
    [SwaggerResponse(200, "List of schedules", typeof(IEnumerable<ScheduleResource>))]
    public async Task<IActionResult> GetAllSchedules()
    {
        var results = await scheduleQueryService.Handle(new GetAllSchedulesQuery());
        var resources = results.Select(ScheduleResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpGet("operacion/{operacionId:int}")]
    [SwaggerOperation(Summary = "Get Schedules by Operacion Id", OperationId = "GetSchedulesByOperacionId")]
    [SwaggerResponse(200, "List of schedules for the given operacion", typeof(IEnumerable<ScheduleResource>))]
    public async Task<IActionResult> GetSchedulesByOperacionId(int operacionId)
    {
        var results = await scheduleQueryService.Handle(new GetSchedulesByOperacionIdQuery(operacionId));
        var resources = results.Select(ScheduleResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete a Schedule", OperationId = "DeleteSchedule")]
    [SwaggerResponse(204, "Schedule deleted")]
    [SwaggerResponse(404, "Schedule not found")]
    public async Task<IActionResult> DeleteSchedule(int id)
    {
        var result = await scheduleCommandService.Handle(new DeleteScheduleCommand(id));
        if (!result) return NotFound($"Schedule with ID {id} not found.");
        return NoContent();
    }
}