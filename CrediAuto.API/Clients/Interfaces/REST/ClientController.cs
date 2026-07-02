using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using CrediAuto.API.Clients.Domain.Model.Commands;
using CrediAuto.API.Clients.Domain.Model.Queries;
using CrediAuto.API.Clients.Domain.Model.ValueObjects;
using CrediAuto.API.Clients.Domain.Services;
using CrediAuto.API.Clients.Interfaces.REST.Resources;
using CrediAuto.API.Clients.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrediAuto.API.Clients.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Client")]
public class ClientController(
    IClientCommandService clientCommandService,
    IClientQueryService clientQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Client", OperationId = "CreateClient")]
    [SwaggerResponse(201, "Created client", typeof(ClientResource))]
    [SwaggerResponse(400, "The client was not created")]
    [SwaggerResponse(409, "A client with the same DNI already exists")]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientResource resource)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var command = CreateClientCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await clientCommandService.Handle(command);
        if (result is null) return Conflict("A client with the same Document Number already exists.");
        return CreatedAtAction(nameof(GetClientById), new { id = result.Id },
            ClientResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Get a Client by Id", OperationId = "GetClientById")]
    [SwaggerResponse(200, "The client was found", typeof(ClientResource))]
    [SwaggerResponse(404, "Client not found")]
    public async Task<IActionResult> GetClientById(int id)
    {
        var result = await clientQueryService.Handle(new GetClientByIdQuery(id));
        if (result is null) return NotFound();
        return Ok(ClientResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all Clients", OperationId = "GetAllClients")]
    [SwaggerResponse(200, "List of clients", typeof(IEnumerable<ClientResource>))]
    public async Task<IActionResult> GetAllClients()
    {
        var results = await clientQueryService.Handle(new GetAllClientsQuery());
        var resources = results.Select(ClientResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpGet("document/{documentNumber}")]
    [SwaggerOperation(Summary = "Get a Client by document number", OperationId = "GetClientByDocumentNumber")]
    [SwaggerResponse(200, "The client was found", typeof(ClientResource))]
    [SwaggerResponse(404, "Client not found")]
    public async Task<IActionResult> GetClientByDocumentNumber(string documentNumber)
    {
        var result = await clientQueryService.Handle(new GetClientByDocumentNumberQuery(documentNumber));
        if (result is null) return NotFound();
        return Ok(ClientResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("user/{userId:int}")]
    [SwaggerOperation(Summary = "Get a Client by UserId", OperationId = "GetClientByUserId")]
    [SwaggerResponse(200, "The client was found", typeof(ClientResource))]
    [SwaggerResponse(404, "Client not found")]
    public async Task<IActionResult> GetClientByUserId(int userId)
    {
        var result = await clientQueryService.Handle(new GetClientByUserIdQuery(userId));
        if (result is null) return NotFound();
        return Ok(ClientResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "Update a Client's contact information", OperationId = "UpdateClient")]
    [SwaggerResponse(200, "Client updated", typeof(ClientResource))]
    [SwaggerResponse(404, "Client not found")]
    public async Task<IActionResult> UpdateClient(int id, [FromBody] UpdateClientResource resource)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var command = new UpdateClientCommand(id, resource.FullName, resource.LastName, resource.Email, resource.Phone);
        var result = await clientCommandService.Handle(command);
        if (result is null) return NotFound($"Client with ID {id} not found.");
        return Ok(ClientResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("status/{status}")]
    [SwaggerOperation(Summary = "Get Clients by status", OperationId = "GetClientsByStatus")]
    [SwaggerResponse(200, "List of clients with the given status", typeof(IEnumerable<ClientResource>))]
    public async Task<IActionResult> GetClientsByStatus(ClientStatus status)
    {
        var results = await clientQueryService.Handle(new GetClientsByStatusQuery(status));
        var resources = results.Select(ClientResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpPatch("{id:int}/status")]
    [SwaggerOperation(Summary = "Update Client status", OperationId = "UpdateClientStatus")]
    [SwaggerResponse(200, "Client status updated", typeof(ClientResource))]
    [SwaggerResponse(404, "Client not found")]
    public async Task<IActionResult> UpdateClientStatus(int id, [FromBody] UpdateClientStatusResource resource)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var command = new UpdateClientStatusCommand(id, resource.Status);
        var result = await clientCommandService.Handle(command);
        if (result is null) return NotFound($"Client with ID {id} not found.");
        return Ok(ClientResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete a Client", OperationId = "DeleteClient")]
    [SwaggerResponse(204, "Client deleted")]
    [SwaggerResponse(404, "Client not found")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var result = await clientCommandService.Handle(new DeleteClientCommand(id));
        if (!result) return NotFound($"Client with ID {id} not found.");
        return NoContent();
    }
}