using System.Net.Mime;
using CrediAuto.API.Simulations.Domain.Model.Commands;
using CrediAuto.API.Simulations.Domain.Model.Queries;
using CrediAuto.API.Simulations.Domain.Services;
using CrediAuto.API.Simulations.Interfaces.REST.Resources;
using CrediAuto.API.Simulations.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrediAuto.API.Simulations.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Simulation")]
public class SimulationController(
    ISimulationCommandService simulationCommandService,
    ISimulationQueryService simulationQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Simulation", OperationId = "CreateSimulation")]
    [SwaggerResponse(201, "Created simulation", typeof(SimulationResource))]
    [SwaggerResponse(400, "The simulation was not created")]
    public async Task<IActionResult> CreateSimulation([FromBody] CreateSimulationResource resource)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var command = CreateSimulationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await simulationCommandService.Handle(command);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetSimulationById), new { id = result.Id },
            SimulationResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Get a Simulation by Id", OperationId = "GetSimulationById")]
    [SwaggerResponse(200, "The simulation was found", typeof(SimulationResource))]
    [SwaggerResponse(404, "Simulation not found")]
    public async Task<IActionResult> GetSimulationById(int id)
    {
        var result = await simulationQueryService.Handle(new GetSimulationByIdQuery(id));
        if (result is null) return NotFound();
        return Ok(SimulationResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all Simulations", OperationId = "GetAllSimulations")]
    [SwaggerResponse(200, "List of simulations", typeof(IEnumerable<SimulationResource>))]
    public async Task<IActionResult> GetAllSimulations()
    {
        var results = await simulationQueryService.Handle(new GetAllSimulationsQuery());
        var resources = results.Select(SimulationResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete a Simulation", OperationId = "DeleteSimulation")]
    [SwaggerResponse(204, "Simulation deleted")]
    [SwaggerResponse(404, "Simulation not found")]
    public async Task<IActionResult> DeleteSimulation(int id)
    {
        var result = await simulationCommandService.Handle(new DeleteSimulationCommand(id));
        if (!result) return NotFound($"Simulation with ID {id} not found.");
        return NoContent();
    }
}