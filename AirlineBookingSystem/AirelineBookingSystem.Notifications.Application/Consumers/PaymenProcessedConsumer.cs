using AirelineBookingSystem.Notifications.Application.Commands;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Notifications.Application.Consumers
{
    public class PaymenProcessedConsumer : IConsumer<PaymentProcessedEvent>
    {
        private readonly IMediator _mediator;

        public PaymenProcessedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<PaymentProcessedEvent> context)
        {
            var paymentProcessedEvent = context.Message;
            var message = $"Received Payment Processed Event: PaymentId-{paymentProcessedEvent.PaymentId}, " +
                $"BookingId-{paymentProcessedEvent.BookingId}, Amount-{paymentProcessedEvent.Amount}, " +
                $"PaymentDate-{paymentProcessedEvent.PaymentDate}";
            var command = new SendNotificationCommand("someone@example.com", message, "Email");
            
            await _mediator.Send(command);
        }
    }
}
