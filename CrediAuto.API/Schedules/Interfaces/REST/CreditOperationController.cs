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
[Tags("CreditOperation")]
public class CreditOperationController(
    ICreditOperationCommandService creditOperationCommandService,
    ICreditOperationQueryService creditOperationQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new CreditOperation", OperationId = "CreateCreditOperation")]
    [SwaggerResponse(201, "Created credit operation", typeof(CreditOperationResource))]
    [SwaggerResponse(400, "The credit operation was not created")]
    public async Task<IActionResult> CreateCreditOperation([FromBody] CreateCreditOperationResource resource)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var command = CreateCreditOperationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await creditOperationCommandService.Handle(command);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetCreditOperationById), new { id = result.Id },
            CreditOperationResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Get a CreditOperation by Id", OperationId = "GetCreditOperationById")]
    [SwaggerResponse(200, "The credit operation was found", typeof(CreditOperationResource))]
    [SwaggerResponse(404, "CreditOperation not found")]
    public async Task<IActionResult> GetCreditOperationById(int id)
    {
        var result = await creditOperationQueryService.Handle(new GetCreditOperationByIdQuery(id));
        if (result is null) return NotFound();
        return Ok(CreditOperationResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all CreditOperations", OperationId = "GetAllCreditOperations")]
    [SwaggerResponse(200, "List of credit operations", typeof(IEnumerable<CreditOperationResource>))]
    public async Task<IActionResult> GetAllCreditOperations()
    {
        var results = await creditOperationQueryService.Handle(new GetAllCreditOperationsQuery());
        var resources = results.Select(CreditOperationResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpGet("client/{clientId:int}")]
    [SwaggerOperation(Summary = "Get CreditOperations by Client Id", OperationId = "GetCreditOperationsByClientId")]
    [SwaggerResponse(200, "List of credit operations for the given client", typeof(IEnumerable<CreditOperationResource>))]
    public async Task<IActionResult> GetCreditOperationsByClientId(int clientId)
    {
        var results = await creditOperationQueryService.Handle(new GetCreditOperationsByClientIdQuery(clientId));
        var resources = results.Select(CreditOperationResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpGet("car/{carId:int}")]
    [SwaggerOperation(Summary = "Get CreditOperations by Car Id", OperationId = "GetCreditOperationsByCarId")]
    [SwaggerResponse(200, "List of credit operations for the given car", typeof(IEnumerable<CreditOperationResource>))]
    public async Task<IActionResult> GetCreditOperationsByCarId(int carId)
    {
        var results = await creditOperationQueryService.Handle(new GetCreditOperationsByCarIdQuery(carId));
        var resources = results.Select(CreditOperationResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete a CreditOperation", OperationId = "DeleteCreditOperation")]
    [SwaggerResponse(204, "CreditOperation deleted")]
    [SwaggerResponse(404, "CreditOperation not found")]
    public async Task<IActionResult> DeleteCreditOperation(int id)
    {
        var result = await creditOperationCommandService.Handle(new DeleteCreditOperationCommand(id));
        if (!result) return NotFound($"CreditOperation with ID {id} not found.");
        return NoContent();
    }
}