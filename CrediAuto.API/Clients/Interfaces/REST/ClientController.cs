using System.Net.Mime;
using CrediAuto.API.Clients.Domain.Model.Commands;
using CrediAuto.API.Clients.Domain.Model.Queries;
using CrediAuto.API.Clients.Domain.Services;
using CrediAuto.API.Clients.Interfaces.REST.Resources;
using CrediAuto.API.Clients.Interfaces.REST.Transform;
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
        if (result is null) return Conflict("A client with the same DNI already exists.");
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

    [HttpGet("dni/{dni}")]
    [SwaggerOperation(Summary = "Get a Client by DNI", OperationId = "GetClientByDni")]
    [SwaggerResponse(200, "The client was found", typeof(ClientResource))]
    [SwaggerResponse(404, "Client not found")]
    public async Task<IActionResult> GetClientByDni(string dni)
    {
        var result = await clientQueryService.Handle(new GetClientByDniQuery(dni));
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
        var command = new UpdateClientCommand(id, resource.Nombre, resource.Email, resource.Telefono);
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