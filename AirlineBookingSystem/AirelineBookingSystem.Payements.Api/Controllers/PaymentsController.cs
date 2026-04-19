using AirelineBookingSystem.Payements.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirelineBookingSystem.Payements.Api.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] ProcessPayementCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(ProcessPayment), new {id}, command);
        }

        [HttpPost("refund/{id}")]
        public async Task<IActionResult> RefundPayment(Guid id)
        {
            await _mediator.Send(new RefundPayementCommand(id));
            return NoContent();
        }

    }
}
