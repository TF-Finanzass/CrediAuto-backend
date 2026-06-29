using System.Net.Mime;
using CrediAuto.API.Payments.Domain.Model.Commands;
using CrediAuto.API.Payments.Domain.Model.Queries;
using CrediAuto.API.Payments.Domain.Services;
using CrediAuto.API.Payments.Interfaces.REST.Resources;
using CrediAuto.API.Payments.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrediAuto.API.Payments.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Payment")]
public class PaymentController(
    IPaymentCommandService paymentCommandService,
    IPaymentQueryService paymentQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Payment", OperationId = "CreatePayment")]
    [SwaggerResponse(201, "Created payment", typeof(PaymentResource))]
    [SwaggerResponse(400, "The payment was not created")]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentResource resource)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var command = CreatePaymentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await paymentCommandService.Handle(command);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetPaymentById), new { id = result.Id },
            PaymentResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Get a Payment by Id", OperationId = "GetPaymentById")]
    [SwaggerResponse(200, "The payment was found", typeof(PaymentResource))]
    [SwaggerResponse(404, "Payment not found")]
    public async Task<IActionResult> GetPaymentById(int id)
    {
        var result = await paymentQueryService.Handle(new GetPaymentByIdQuery(id));
        if (result is null) return NotFound();
        return Ok(PaymentResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all Payments", OperationId = "GetAllPayments")]
    [SwaggerResponse(200, "List of payments", typeof(IEnumerable<PaymentResource>))]
    public async Task<IActionResult> GetAllPayments()
    {
        var results = await paymentQueryService.Handle(new GetAllPaymentsQuery());
        var resources = results.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpGet("cronograma/{cronogramaId:int}")]
    [SwaggerOperation(Summary = "Get Payments by Cronograma Id", OperationId = "GetPaymentsByCronogramaId")]
    [SwaggerResponse(200, "List of payments for the given cronograma", typeof(IEnumerable<PaymentResource>))]
    public async Task<IActionResult> GetPaymentsByCronogramaId(int cronogramaId)
    {
        var results = await paymentQueryService.Handle(new GetPaymentsByCronogramaIdQuery(cronogramaId));
        var resources = results.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete a Payment", OperationId = "DeletePayment")]
    [SwaggerResponse(204, "Payment deleted")]
    [SwaggerResponse(404, "Payment not found")]
    public async Task<IActionResult> DeletePayment(int id)
    {
        var result = await paymentCommandService.Handle(new DeletePaymentCommand(id));
        if (!result) return NotFound($"Payment with ID {id} not found.");
        return NoContent();
    }
}