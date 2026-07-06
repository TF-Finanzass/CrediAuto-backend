using System.Net.Mime;
using CrediAuto.API.Cars.Domain.Model.Commands;
using CrediAuto.API.Cars.Domain.Model.Queries;
using CrediAuto.API.Cars.Domain.Model.ValueObjects;
using CrediAuto.API.Cars.Domain.Services;
using CrediAuto.API.Cars.Interfaces.REST.Resources;
using CrediAuto.API.Cars.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrediAuto.API.Cars.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Car")]
public class CarController(
    ICarCommandService carCommandService,
    ICarQueryService carQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Car", OperationId = "CreateCar")]
    [SwaggerResponse(201, "Created car", typeof(CarResource))]
    [SwaggerResponse(400, "The car was not created")]
    public async Task<IActionResult> CreateCar([FromBody] CreateCarResource resource)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var command = CreateCarCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await carCommandService.Handle(command);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetCarById), new { id = result.Id },
            CarResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Get a Car by Id", OperationId = "GetCarById")]
    [SwaggerResponse(200, "The car was found", typeof(CarResource))]
    [SwaggerResponse(404, "Car not found")]
    public async Task<IActionResult> GetCarById(int id)
    {
        var result = await carQueryService.Handle(new GetCarByIdQuery(id));
        if (result is null) return NotFound();
        return Ok(CarResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Get all Cars", OperationId = "GetAllCars")]
    [SwaggerResponse(200, "List of cars", typeof(IEnumerable<CarResource>))]
    public async Task<IActionResult> GetAllCars()
    {
        var results = await carQueryService.Handle(new GetAllCarsQuery());
        var resources = results.Select(CarResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpGet("status/{status}")]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Get Cars by status", OperationId = "GetCarsByStatus")]
    [SwaggerResponse(200, "List of cars with the given status", typeof(IEnumerable<CarResource>))]
    public async Task<IActionResult> GetCarsByStatus(CarStatus status)
    {
        var results = await carQueryService.Handle(new GetCarsByStatusQuery(status));
        var resources = results.Select(CarResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpPatch("{id:int}/status")]
    [SwaggerOperation(Summary = "Update Car status", OperationId = "UpdateCarStatus")]
    [SwaggerResponse(200, "Car status updated", typeof(CarResource))]
    [SwaggerResponse(404, "Car not found")]
    public async Task<IActionResult> UpdateCarStatus(int id, [FromBody] UpdateCarStatusResource resource)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var command = new UpdateCarStatusCommand(id, resource.Status);
        var result = await carCommandService.Handle(command);
        if (result is null) return NotFound($"Car with ID {id} not found.");
        return Ok(CarResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete a Car", OperationId = "DeleteCar")]
    [SwaggerResponse(204, "Car deleted")]
    [SwaggerResponse(404, "Car not found")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var result = await carCommandService.Handle(new DeleteCarCommand(id));
        if (!result) return NotFound($"Car with ID {id} not found.");
        return NoContent();
    }
    
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "Update a Car", OperationId = "UpdateCar")]
    [SwaggerResponse(200, "Car updated", typeof(CarResource))]
    [SwaggerResponse(404, "Car not found")]
    public async Task<IActionResult> UpdateCar(int id, [FromBody] UpdateCarResource resource)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var command = UpdateCarCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await carCommandService.Handle(command);
        if (result is null) return NotFound($"Car with ID {id} not found.");
        return Ok(CarResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
}